//-----------------------------------------------------------------------
// <copyright file="SimpleScrobblerForm.cs" company="Vyacheslav Lisnevskyi">
//     Copyright Vyacheslav Lisnevskyi. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Last.fm.API;
using Last.fm.API.Auth;
using Last.fm.API.Core;
using Last.fm.API.Core.Types;
using Last.fm.API.User;

namespace SimpleScrobbler
{
    public partial class SimpleScrobblerForm : Form
    {
        private bool isLogedIn = false;
        private AuthToken token;
        private AuthSession userSession;
        private UserInfo userInfo;
        private RecentTracksCollection rt;

        public SimpleScrobblerForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null != userInfo)
            {
                Process.Start(userInfo.ProfileUrl);
            }
        }

        private void NotAuthorizedToken(object sender, NotAuthorizedTokenEventArgs e)
        {
            IAuthServices client = sender as IAuthServices;
            if (null != client)
            {
                token = client.GetToken();
                AuthorizationForm authorization = new AuthorizationForm(token.Url);
                if (authorization.ShowDialog() == DialogResult.OK)
                {
                    e.NewToken = token;
                    e.Resolved = true;
                }
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!isLogedIn)
            {
                using (IAuthServices client = LastFmServices.AuthServicesClient)
                {
                    //userSession = client.GetMobileSession("password", "username");
                    if (null == userSession)
                    {
                        client.NotAuthorizedToken += new EventHandler<NotAuthorizedTokenEventArgs>(NotAuthorizedToken);
                        userSession = client.GetSession();
                        isLogedIn = true;
                    }
                }

                if (null != userSession)
                {
                    using (IUserServices client = LastFmServices.UserServicesClient)
                    {
                        //var test = client.GetTopTags("RJ");
                        var test = client.GetArtistTracks("RJ", "metallica");
                        userInfo = client.GetInfo(userSession.UserName);
                        rt = client.GetRecentTracks(userSession.UserName, 200, extended: true);
                        if (null != rt)
                        {
                            recentTracks.Items.Clear();
                            recentTracks.Items.AddRange(rt.ToArray());
                        }
                    }
                }
            }
            else
            {
                isLogedIn = false;
                userInfo = null;
                userSession = null;
            }

            if (isLogedIn && null != userInfo)
            {
                lbUser.Text = string.Format("User: {0}", userInfo.Name);
                lbName.Text = string.Format("Name: {0}", userInfo.RealName);
                lbCountry.Text = string.Format("Country : {0}", userInfo.Country);
                lbPlayCount.Text = string.Format("Played count: {0}", userInfo.PlayCount);

                using (WebClient client = new WebClient())
                {
                    string fileUrl = userInfo.Images.FirstOrDefault(imgUrl => imgUrl.Size == ImageSize.large);

                    byte[] img = client.DownloadData(string.IsNullOrWhiteSpace(fileUrl) ? userInfo.Images[0] : fileUrl);
                    MemoryStream ms = new MemoryStream(img);
                    userImg.Image = new Bitmap(ms);
                }

                btnLogIn.Text = "Log Out";
            }
            else
            {
                lbUser.Text = "User: ";
                lbName.Text = "Name: ";
                lbCountry.Text = "Country : ";
                lbPlayCount.Text = "Played count: ";

                userImg.Image = userImg.InitialImage;
                btnLogIn.Text = "Log In";
            }
        }
    }
}
