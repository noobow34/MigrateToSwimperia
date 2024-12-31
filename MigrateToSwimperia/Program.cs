using ClosedXML.Excel;
using MigrateToSwimperia;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

ChromeDriver driver = new();
try
{
    //設定ファイルからログイン情報取得
    //設定ファイルにメールアドレスとパスワードを設定してください
    string mail = Settings1.Default.mail;
    string password = Settings1.Default.password;

    //ログイン
    driver.Navigate().GoToUrl("https://swimperia.com/");
    driver.FindElement(By.XPath(@"/html/body/main/div[2]/div/div[1]/div/div[2]/a")).Click();
    driver.FindElement(By.Name("mail")).SendKeys(mail);
    driver.FindElement(By.Name("password")).SendKeys(password);
    driver.FindElement(By.ClassName("gologinbutton")).Click();

    //importdata.xlsxのフォーマットを指定してインポートデータを作成してください
    //ファイルパスは配置場所に合わせて書き換えてください
    using var workbook = new XLWorkbook(@"importdata.xlsx");
    var worksheet = workbook.Worksheet("Sheet1");
    int line = 2;

    //記入内容の取得
    string year = worksheet.Cell($"A{line}").Value.ToString();
    string month = worksheet.Cell($"B{line}").Value.ToString();
    string day = worksheet.Cell($"C{line}").Value.ToString();
    string distance = worksheet.Cell($"D{line}").Value.ToString();
    string record = worksheet.Cell($"E{line}").Value.ToString();
    while (!string.IsNullOrEmpty(year))
    {
        //新規投稿
        driver.Navigate().GoToUrl("https://swimperia.com/nyuryoku1.php");

        //水中トレーニングの日誌
        //年
        new SelectElement(driver.FindElement(By.Name("years"))).SelectByText($"{year}年");
        //月
        new SelectElement(driver.FindElement(By.Name("months"))).SelectByText($"{month}月");
        //日
        new SelectElement(driver.FindElement(By.Name("days"))).SelectByText($"{day}日");

        //記録記入
        driver.FindElement(By.Id("templateTextArea")).SendKeys($"{record}");

        //距離入力
        driver.FindElement(By.Name("total")).SendKeys($"{distance}");

        Console.WriteLine($"{year}/{month}/{day} {distance}m {record}");

        //投稿する
        driver.FindElement(By.Id("submitbutton")).Click();

        //5秒待機
        await Task.Delay(5000);

        line++;

        year = worksheet.Cell($"A{line}").Value.ToString();
        month = worksheet.Cell($"B{line}").Value.ToString();
        day = worksheet.Cell($"C{line}").Value.ToString();
        distance = worksheet.Cell($"D{line}").Value.ToString();
        record = worksheet.Cell($"E{line}").Value.ToString();
    }
}   
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    driver.Quit();
}