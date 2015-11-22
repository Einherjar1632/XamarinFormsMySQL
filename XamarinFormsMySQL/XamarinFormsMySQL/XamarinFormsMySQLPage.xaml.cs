using System;
using MySql.Data.MySqlClient;
using Xamarin.Forms;
using I18N.West;

namespace XamarinFormsMySQL
{
	public partial class XamarinFormsMySQLPage : ContentPage
	{
		public XamarinFormsMySQLPage ()
		{
			InitializeComponent ();
		}

        public void OnButtonClicked(object sender, EventArgs args)
        {
            try
            {
                //http://blog.snowwolf725.jjvk.com/2014/12/11/tutorial-how-to-connect-mysql-database-in-xamarin-android-ios/
                new CP1250();

                var cs = string.Format("Server=YourIPAddress;Port=3306;database=YourDatabase;User Id=YourID;Password=YourPassword;charset=utf8");
                using(var db = new MySqlConnection(cs))
                {
                    db.Open();
                    var queryString = "select hello from helloxamarin";
                    var sqlcmd = new MySqlCommand(queryString, db);
                    var result = sqlcmd.ExecuteScalar().ToString();
                    LblMsg.Text = result;
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                LblMsg.Text = ex.ToString();
            }
        }

    }
}
