using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Verify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                ImageVerifierService.ServiceClient verifier = new ImageVerifierService.ServiceClient();
                String captcha = verifier.GetVerifierString("5");
                Session["captcha"] = captcha;
                CaptchaImage.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captcha;
            }
            catch { }

        }
    }

    protected void nextButton_Click(object sender, EventArgs e)
    {
        try
        {
            String SessionCaptcha = "";
            String captcha = CaptchaTb.Text;
            if (Session["captcha"] != null)
            {
                SessionCaptcha = Session["captcha"].ToString();
            }

            if (SessionCaptcha.Equals(captcha))
            {
                Response.Redirect("~/MemberSignUp.aspx");
            }
            else
            {
                ImageVerifierService.ServiceClient verifier = new ImageVerifierService.ServiceClient();
                String captchaService = verifier.GetVerifierString("5");
                Session["captcha"] = captchaService;
                CaptchaImage.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captchaService;
                captchaErrorLbl.Text = "Wrong Captcha Entered";
            }
        }
        catch { }

    }

    protected void ReloadImageButton_Click(object sender, EventArgs e)
    {
        try
        {
            ImageVerifierService.ServiceClient verifier = new ImageVerifierService.ServiceClient();
            String captcha = verifier.GetVerifierString("5");
            Session["captcha"] = captcha;
            CaptchaImage.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + captcha;
        }
        catch { }
    }

    protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}