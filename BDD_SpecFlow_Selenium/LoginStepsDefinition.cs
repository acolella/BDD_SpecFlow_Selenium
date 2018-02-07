using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace BDD_SpecFlow_Selenium
{
    [Binding]
    public class LoginSteps
    {

        IWebDriver Browser;
        private string uri = "http://www.voeazul.com.br";

        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();
            this.Browser.Manage().Window.Maximize();
                        
        }

        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"Um visitante não cadastrado acessar a tela de login")]
        public void DadoUmVisitanteNaoCadastradoAcessarATelaDeLogin()
        {
            this.Browser.Navigate().GoToUrl(uri);
        }
        
        [When(@"Preencher todos os campos de login")]
        public void QuandoPreencherTodosOsCamposDeLogin(Table table)
        {

            Thread.Sleep(10000);

            var txtCPF = this.Browser.FindElement(By.Id("login-username"));
            txtCPF.SendKeys(table.Rows[0][0].ToString());

            Thread.Sleep(3000);

            var txtSenha = this.Browser.FindElement(By.XPath("//input[@name='password']"));
            txtSenha.SendKeys(table.Rows[0][1].ToString());

            Thread.Sleep(3000);

            var btnOK = this.Browser.FindElement(By.LinkText("OK"));
            Thread.Sleep(2000);
            btnOK.Click();
                                 
        }
        
        [Then(@"será apresentado a mensagem de erro ""(.*)""")]
        public void EntaoSeraApresentadoAMensagemDeErro(string p0)
        {

            Thread.Sleep(15000);
                
            var lblMensagemErro = this.Browser.FindElement(By.ClassName("button-0001 skin-0085"));
            Assert.AreEqual("Fechar esta janela",lblMensagemErro.Text);
        }
    }
}
