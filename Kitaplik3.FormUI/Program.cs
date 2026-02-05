namespace Kitaplik3.FormUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}


//Katmanlý Mimari Nedir

//Temel anlamda üç katmandan oluþuyor ihtiyaçlar doðrultusunda katman sayýsý arttýrýlmaktadýr.

//Üç katmanlý mimari

// 1) Gösterim (UI,Presentation)  Katmaný ;Son kullanýcýnýn uygulamayla etkileþim kurduðu, uygulamanýn iletiþim katmaný ve kullanýcý arayüzüdür. Öncelikli amacý, kullanýcýya bilgileri göstermek ve kullanýcýdan bilgileri toplamaktýr.

// 2) Veri Katmaný (Data Access Layer); Verilerimizi yöneten katman. uygulama tarafýndan iþlenen bilgilerin depolandýðý ve yönetildiði yerdir.(CRUD) iþlemleri yapýlýr.

// 3) Uygulama (Business) Katmaný; Ara katman olarakta bilinen uygulama katmanýdýr. Uygulamanýn kalbidir. bu katmanda, gösterim katmanýnda toplanan bilgiler, kimi zaman veri katmanýndaki diðer bilgilere göre, belli bir iþ kurallarý kümesiyle iþ mantýðý kullanýlarak iþlenir. Uygulama katmanaý veri katmanýndaki verileri ekleyebilir, silebilir ya da deðiþtirebilir.

//Avantajlarý

//Her bir katman farklý ekipler tarafýndan eþ zamanlý olarak geliþtirilebildiðinden bir kuruluþ, uygulamayý pazara daha hýzlý çýkarabilir ve programcýlar her  katman için en son ve en iyi dilleri ve araçlarý kullanabilir

//Tüm katmanlar gerektiðinde diðerlerinden baðýmsýz olarak ölçeklenebilir

//Bir katmandaki kesintinin diðer katmalarýn kullanýlabilirliðini ya da performansýný etkileme olasýlýðý düþüktür.

//Gösterim(UI) katmaný ve veri katmaný doðrudan iletiþim kuramadýðýndan iyi tasarýmlý bir uygulama katmaný, içeride güvenlik duvarý gibi iþlev görerek SQL eklemelerinin ve diðer kötüye kullanýmlarýn önlenmesini saðlayabilir.
