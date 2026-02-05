using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
//Repository design pattern - bak, uygula
namespace Kitaplik3.ConsoleUI;

internal class Program
{
    BookManager _bookManager = new BookManager();
    CategoryManager _categoryManager = new CategoryManager();
    AuthorManager _authorManager = new AuthorManager();
    PublisherManager _publisherManager = new PublisherManager();

    static void Main(string[] args)
    {
        Program program = new Program();   
        do
        {
            Console.Clear();
            Console.Write("== İşlemi Seçiniz ==\n\n1> Kitap Sekmesi\n2> Yazar Sekmesi\n3> Kategori Sekmesi\n4> Yayıncı Sekmesi\n\n-->");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Clear();
                    program.BookSekmesi();
                    break;
                case 2:
                    Console.Clear();
                    program.authorSekmesi();
                    break;
                case 3:
                    Console.Clear();
                    program.CategorySekmesi();
                    break;
                case 4:
                    Console.Clear();
                    program.PublisherSekmesi();
                    break;
                default:
                    break;
            }
        }
        while (true);
    }

    #region Book

    public void BookSekmesi()
    {
        Console.WriteLine("=Kitaplar=\n");
        BookListele();
        Console.Write("\n1> Ekle\n2> Sil\n3> Geri\n\nİşlem Giriniz\n-->");
        int secim = int.Parse(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.Clear();
                BookEkle();
                break;
            case 2:
                Console.Clear();
                BookSil();
                break;
            default:
                break;
        }
    }

    public void BookEkle()
    {
        Book book = new Book();

        Console.Write("Kitabın İsmini Giriniz: ");
        book.Name = Console.ReadLine();
        Console.Write("Kitabın ISBN numarasını Giriniz: ");
        book.ISBN = Console.ReadLine();
        Console.Clear();

        AuthorListele();
        Console.Write("\nKitabın yazarının ID'sini giriniz\n-->");
        book.AuthorId = int.Parse(Console.ReadLine());
        Console.Clear();

        CategoryListele();
        Console.Write("\nKitabın Kategorisin ID'sini giriniz\n--> ");
        book.CategoryId = int.Parse(Console.ReadLine());
        Console.Clear();

        PublisherListele();
        Console.WriteLine("\nKitabın Yayıncısının ID'sini giriniz\n-->");
        book.PublisherId = int.Parse(Console.ReadLine());
        Console.Clear();

        _bookManager.Add(book);

        Console.WriteLine("İşlem Başarıyla Tamamlandı");
        Console.ReadKey();

    }

    public void BookSil()
    {
        BookListele();
        Console.WriteLine("Silinecek Kitabın ID'si: ");
        int ID = int.Parse(Console.ReadLine());
        Book book = _bookManager.GetById(ID);

        _bookManager.Delete(book);

        Console.Clear();
        Console.WriteLine("İşlem Başarıyla Tamamlandı");
        Console.ReadKey();

    }

    public void BookListele()
    {
        List<Book> books = new List<Book>();
        books = _bookManager.GetAll();
        foreach (var item in books)
        {
            Console.WriteLine($"[{item.Id}] {item.Name} ({item.ISBN})");
        }
    }

    #endregion

    #region Author

    public void authorSekmesi()
    {
        Console.WriteLine("=YAZARLAR=\n");
        AuthorListele();
        Console.Write("\n1> Ekle\n2> Sil\n3> Güncelle\n4> Geri\n\nİşlem Giriniz\n-->");
        int secim = int.Parse(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.Clear();
                AuthorEkle();
                break;
            case 2:
                Console.Clear();
                AuthorSil();
                break;
            case 3:
                Console.Clear();
                AuthorGüncelle();
                break;
            default:
                break;
        }
    }

    public void AuthorEkle()
    {
        AuthorListele();
        Author author = new Author();
        Console.Write("\nEklenecek Yazarın İsmi: ");
        author.Name = Console.ReadLine();
        _authorManager.Add(author);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void AuthorSil()
    {
        AuthorListele();
        Console.Write("\nSilinecek Yazarın ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Author author = _authorManager.GetById(Id);
        _authorManager.Delete(author);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void AuthorGüncelle()
    {
        AuthorListele();
        Console.Write("\n Güncellenecek Yazarın ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Console.Write("\n Güncellenecek Yazarın Yeni İsmi: ");
        string ad = Console.ReadLine();
        Author author = _authorManager.GetById(Id);
        author.Name = ad;
        _authorManager.Update(author);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void AuthorListele()
    {
        List<Author> authors = new List<Author>();
        authors = _authorManager.GetAll();
        foreach (var author in authors)
        {
            Console.WriteLine($"[{author.Id}] - {author.Name}");
        }
    }

    #endregion

    #region Category

    public void CategorySekmesi()
    {
        Console.WriteLine("=KATEGORİLER=\n");
        CategoryListele();
        Console.Write("\n1> Ekle\n2> Sil\n3> Güncelle\n4> Geri\n\nİşlem Giriniz\n-->");
        int secim = int.Parse(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.Clear();
                CategoryEkle();
                break;
            case 2:
                Console.Clear();
                CategorySil();
                break;
            case 3:
                Console.Clear();
                CategoryGüncelle();
                break;
            default:
                break;
        }
    }

    public void CategoryEkle()
    {
        CategoryListele();
        Category category = new Category();
        Console.Write("\nEklenecek Kategori İsmi: ");
        category.Name = Console.ReadLine();
        _categoryManager.Add(category);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void CategorySil()
    {
        CategoryListele();
        Console.Write("\nSilinecek Kategori ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Category category = _categoryManager.GetById(Id);
        _categoryManager.Delete(category);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void CategoryGüncelle()
    {
        CategoryListele();
        Console.Write("\n Güncellenecek Kategori ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Console.Write("\n Güncellenecek Kategori'nin Yeni İsmi: ");
        string ad = Console.ReadLine();
        Category category = _categoryManager.GetById(Id);
        category.Name = ad;
        _categoryManager.Update(category);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void CategoryListele()
    {
        List<Category> categories = new List<Category>();
        categories = _categoryManager.GetAll();
        foreach (var item in categories)
        {
            Console.WriteLine($"[{item.Id}] {item.Name}");
        }
    }

    #endregion

    #region Publisher

    public void PublisherSekmesi()
    {
        Console.WriteLine("=YAYINCILAR=\n");
        PublisherListele();
        Console.Write("\n1> Ekle\n2> Sil\n3> Güncelle\n4> Geri\n\nİşlem Giriniz\n-->");
        int secim = int.Parse(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.Clear();
                PublisherEkle();
                break;
            case 2:
                Console.Clear();
                PublisherSil();
                break;
            case 3:
                Console.Clear();
                PublisherGüncelle();
                break;
            default:
                break;
        }
    }

    public void PublisherEkle()
    {
        PublisherListele();
        Publisher publisher = new Publisher();
        Console.Write("\nEklenecek Yayıncının İsmi: ");
        publisher.Name = Console.ReadLine();
        _publisherManager.Add(publisher);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void PublisherSil()
    {
        PublisherListele();
        Console.Write("\nSilinecek Yayıncının ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Publisher publisher = _publisherManager.GetById(Id);
        _publisherManager.Delete(publisher);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void PublisherGüncelle()
    {
        PublisherListele();
        Console.Write("\n Güncellenecek Yayıncının ID'si: ");
        int Id = int.Parse(Console.ReadLine());
        Console.Write("\n Güncellenecek Yayıncının Yeni İsmi: ");
        string ad = Console.ReadLine();
        Publisher publisher = _publisherManager.GetById(Id);
        publisher.Name = ad;
        _publisherManager.Update(publisher);

        Console.Clear();
        Console.WriteLine("İşlem Başarılı");
        Console.ReadKey();
    }

    public void PublisherListele()
    {
        List<Publisher> publishers = new List<Publisher>();
        publishers = _publisherManager.GetAll();
        foreach (var publisher in publishers)
        {
            Console.WriteLine($"[{publisher.Id}] - {publisher.Name}");
        }
    }

    #endregion
}
