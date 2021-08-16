# PROJEMVCKAMP-
MURAT YÜCEDAĞ MVC PROJE KAMPI

MVC 
3 Temel yapıya dayanır:
MODEL: İşin veritabanı na ait entity dediğimiz kısımlarının tanımlandığı kısım
VİEW: İşin tasarım görsel frontend işlemlerinin yapıldığı kısım
CONTROLLER: İşin backend c# kodlama dilinin olduğu alan

ACTİONRESULT: Aksiyon sonucu türünde tanımlanma

N Katmanlı mimari
1- Entity Layer:
2- DataAccessLayer:
3-BusinessLayer: İş Katmanı
4- Presentation Layer User Interface: Sunum Katmanı


-----------
1-)
Başlıklar(Tablo)
Başlık ID
Başlık İsim
Başlık Tarih
Başlık Yazar 
---------------------
2-)
Crud
Create (oluşturma kaydetme), Read (Okuma), Update (Güncelleme), Delete(Silme), Filter(sadece istenen sonuçları getirir)
----------------
3-)
ürünün kaydını gerçekleştirirken istenilen şartların sağlanıp sağlanılmadığı Business Layer katmanında gerçekleştirilir.
------------------
4-)
-------------------
Katman ekleme:
Solution a sağ tık new project visual c# den class library seçilerek katman ismi verilir ve oluşturulur

----------------
Entity framework code first
--------------

Tablolar
____________________
Heading(Başlıklar)
Content(İçerik)
Writer(Yazar)
Contact(İletişim)
About(Hakkımızda) 

------------------------
Somut olarak tutulan ifadeler Concrete klasörü içerisinde tutuluyor
Soyut ifadeler de abstract klasörü içerisinde tutulur  

category sınıfı içerisinde
     public ICollection<Heading> Headings { get; set; }
heading sınıfında category türünde bir property tanımlayarak
     public int CategoryID { get; set; }
     public virtual Category Category { get; set; }
ile category ve heading arasında bire çok ilişki  tamamlanır

heading sınıfı içerisinde
	public ICollection<Content> Contents { get; set; }
Content sınıfında heading türünde bir property tanımlayarak
 	public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
ile heading ve content arasında bire çok ilişki  tamamlanır

sınıflara keyler ve stringllenth verildikten sonra

dataacceslayer katmanında concrate klasörü oluşturulur ve
içerisinde context sınıfı tanımlanır

web config-->
proje ile ilgili yapılandırma ayarlarının yapıldığı kısımdır.
örneğin 
	-projenin veri tabanı bağlantı adresi
	-projenin 404 sayfalarıyla ilgili ayarları
	-projenin oturum ayarları
	-projenin yetkilendirme ayarları
burada gerçekleştirilir.

systemweb in altına
<connectionStrings>
		<add name="Context" connectionString="data source=BULUTS;
			 initial catalog=DbMvcKamp; integrated security=true;" providerName="System.Data.SqlClient"/>
	</connectionStrings>
ifadesi tanımlanır.

package manager console den 
dataaccesslayer katmanı seçilerek 
enable-migrations komutuyla migrationlar aktifleştirilir
 

Crud işlemleri
interface--> sınıflara rehberlik edicek olan yapı

DRY YAPISINI ARAŞTIR !! +

DataAccessLayer katmanında Abstract isminde klasör oluşturulur
sağ tıklayıp yeni bir öğe ekle diyip Interface seçilir
adlandırılırken başına büyük I harfi kullanılır dan sonra görevi neyse o görevinde baş harfi büyük kullanılır.
örneğin ICategory bunun dataaccesslayer katmanında olduğunu belirtmek için ICategoryDal şeklinde tanımlanır

içerisinde
    List<Category> List();
şeklinde türü list olan ismide list olan bir metod tanımladık

   void Insert(Category p);//ekleme
   void Update(Category p);//güncelleme
   void Delete(Category p);//silme
ekleme işlemi gerçekleşmesi için category sınıfında gelen bir p parametresi aracılığıyla category sınıfında yer alan propertylere 
erişim sağlayabileceğiz.

dataacceslayer katmanında concrate klasörü içerisinde Repositories adlı bir klasör oluşturup
bu klasör crude işlemlerini yapabilmemiz için yapıcağımız ifadeleri tutucak
içerisine CategoryRepository adında bir class oluşturuyoruz

bu sınıfı ICategoryDal sınıfından miras alıyoruz ve metotları sınıfın içerisine implemente ediyoruz
        Context c = new Context();
        DbSet<Category> _object; //category sınıfının değerlerini tutar
tanımlamaları yapılır
/*Entity framework işlemleri
    ToList -->Listeleme
    Add    -->Ekleme
    Remove -->Silme
    Find   -->Bulma
 */

abstract klasörüne sağ tıklayıp 
temel repository işlemleri için IRepository adında bir interface oluşturuyoruz

bu yapıya kategori değilde dışarıdan gelicek olan entity yani tabloyu göndermemiz gerekli
bunun için 
public interface IRepository<T> yanına bir T değeri gönderiyoruz bu değer entity i karşılayacak
hangi entity ? sql den hangi entity i gönderirsek onu category, about vs

   List<T> List();
   void Insert(T p);
   void Delete(T p);
   void Update(T p);

şeklinde t den parametre alarak crude işlemleri tanımlanır.


abstract klasörüne IAboutDal adında ınterface tanımlanır 

public interface IAboutDal:IRepository<About> şeklinde IRepository den miras alır


abstract klasörüne IContactDal adında ınterface tanımlanır 

public interface IContactDal:IRepository<Contact> şeklinde IRepository den miras alır

Content,Heading,Writer için aynı işlemleri yapıp

bu şekilde işlemlerimizi kısmen generic hale getirmiş olduk.

aynı şekilde ICategoryDal interface nde de miras alınır

IRepository içerisinde 

List<T> List(Expression<Func<T, bool>> filter);

metodu ile şartlı listeleme yapıcak
örneğin yazar adı ali olanları bu metod sayesinde getiricez bu sayede diğer tüm interfaceler 
için bu metod eklenmiş oldu.

concrate içerisindeki repositories içerisine WriterRepository adında yeni bir class oluşturup
IWriterDal sınıfından miras alarak metodları implemente ederiz

-----------
Generic Repository-->bütün bileşenlerin tamamını kapsıyor
-----------------

Repositories klasörüne sağ tıklayıp GenericRepository adında bir sınıf tanımlanır

 public class GenericRepository<T>:IRepository<T> where T:class

class ın aldığı değerleri t ye eklemiş olduk

Irepository metodlarını implemente edip

  Context c = new Context();
  DbSet<T> _object;
tanımlanır

ctor yazıp tab+tab yaparak oluşturduğumuz sınıfla aynı isimde bir contractor method oluşturduk
bu metodun içinde
_object = c.Set<T>();
context e bağlı olarak gönderilen T değeri olucak object isimli değişkeniö 

metodların içerisi doldurulur ve
artık genericrepository isimli sınıfım sayesinde bütün sınıflarımda ve bütün interfacelerimde
geçerli olan mimariyi kurmaya başladım

amaç kod tekrarından kurtulmak
işlemler daha düzenli bir şekilde ilerlesin
böl parçala yaklaşımında proje geliştirmek

--------------
BusinessLayer(İş Katmanı)-->İşin genellikle geçerliliğinin ve kurallarının kontrolü yapılır
--------------
ekleme-silme-güncelleme-listeleme işlemleri gerçekleştirilirken bizim gönderdiğimiz 
şartların sağlanıp sağlanmadığının kontrolü Business katmanında gerçekleştirilir.

BusinessLayer katmanına sağ tıklayıp concrate adında bir klasör oluşturulur

------------------------------------------
Entity katmanında referans olarak herhangi bir katman kullanılmıyor
DataAcces katmanında Entity katmanı referans olarak kullanılıyor
Business katmanında Entity ve DataAccess kullanılıyor
Sunum katmanında Entity, DataAccess ve Business katmanları referans olarak kullanılıyor
------------------------------------------

BusinessLayer a referans olarak nuget package manager den entity framework ü ekliyoruz

Concrate içerisine CategoryManager isminde bir class oluştup
metodun içerisine
      GenericRepository<Category> repo = new GenericRepository<Category>();
sırasıyla her bir crude işlemi için ya da yapıcağımız işlem her ne ise o işleme ait metodlar tanımlanır

        public List<Category> GetAll()-->hepsini getir
        {//. koyduktan sonra GenericRepository sınıfın içerisinde bulunan tüm methodlar gelir
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {//. koyduktan sonra (Category tablosunua ait sütunlar gelir
//CategoryName boş ise veya CategoryName uzunluğu 3 ten küçükse veya CategoryDesctription boş ise veya
CategoryName uzunluğu 51 den büyükse//   
             if (p.CategoryName == "" || p.CategoryName.Length<=3 ||
		 p.CategoryDesctription=="" || p.CategoryName.Length>=51)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(p);//aksi durumda ekle
            }
        }


----------------
Sunum Katmanı
---------------
Controller a sağ tıklayıp CategoryController oluşturulur
ındex e sağ tık layout kullanmadan view oluştur ve basit bir tablo örneği




























 












 











