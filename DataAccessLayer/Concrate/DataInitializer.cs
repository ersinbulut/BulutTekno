using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {CategoryName="Eğitim", CategoryDesctription="burası eğitim kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Tiyatro", CategoryDesctription="burası tiyatro kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Kitap", CategoryDesctription="burası kitap kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Kitap", CategoryDesctription="burası kitap kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Spor", CategoryDesctription="burası spor kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Film", CategoryDesctription="burası Film kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Dizi", CategoryDesctription="burası Dizi kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Sosyal Medya", CategoryDesctription="burası Sosyal Medya kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Yazılım", CategoryDesctription="burası Yazılım kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="MVC", CategoryDesctription="burası Mvc kategorisidir",CategoryStatus=true,ParentID=17},
                new Category() {CategoryName="Seyehat", CategoryDesctription="burası Seyehat kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Teknoloji", CategoryDesctription="burası Teknoloji kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Araçlar", CategoryDesctription="burası Araçlar kategorisidir",CategoryStatus=true,ParentID=0},
                new Category() {CategoryName="Gündem", CategoryDesctription="burası Gündem kategorisidir",CategoryStatus=true,ParentID=0},

            };
            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            var basliklar = new List<Heading>()
            {
                new Heading() {HeadingName="Breaking Bad",HeadingDate=DateTime.Now,CategoryID=6,WriterID=3,HeadingStatus=true,ImageUrl="https://media-cdn.t24.com.tr/media/library/2020/12/1607331606630-b.jpg",Slider=false },
                 new Heading() {HeadingName="Green Book",HeadingDate=DateTime.Now,CategoryID=5,WriterID=1,HeadingStatus=false,ImageUrl="https://mozartcultures.com/wp-content/uploads/2019/05/green-book-yesil-rehber.jpg",Slider=false },
                  new Heading() {HeadingName="Breaking Bad",HeadingDate=DateTime.Now,CategoryID=6,WriterID=3,HeadingStatus=true,ImageUrl="https://media-cdn.t24.com.tr/media/library/2020/12/1607331606630-b.jpg",Slider=false },


            };

            foreach (var item in basliklar)
            {
                context.Headings.Add(item);
            }
            context.SaveChanges();


            var icerikler = new List<Content>()
            {
                new Content() {ContentValue="Bu film 2019 yılında oscar almaya hak kazandı",ContentDate=DateTime.Now,HeadingID=2,WriterID=1,ContentStatus=true,ImageUrl1="/BlogTECH/upload/ö.jpg",ImageUrl2="/BlogTECH/upload/ö.jpg",ImageUrl3="/BlogTECH/upload/ö.jpg"},
                  new Content() {ContentValue="Çok beğendiğim efsane bir film olmuş",ContentDate=DateTime.Now,HeadingID=2,WriterID=3,ContentStatus=true,ImageUrl1="/BlogTECH/upload/ö.jpg",ImageUrl2="/BlogTECH/upload/ö.jpg",ImageUrl3="/BlogTECH/upload/ö.jpg"},
                   new Content() {ContentValue="hayatımda izlediğim en iyi 10 filmden biri",ContentDate=DateTime.Now,HeadingID=2,WriterID=5,ContentStatus=true,ImageUrl1="/BlogTECH/upload/ö.jpg",ImageUrl2="/BlogTECH/upload/ö.jpg",ImageUrl3="/BlogTECH/upload/ö.jpg"},


            };

            foreach (var item in icerikler)
            {
                context.Contents.Add(item);
            }
            context.SaveChanges();


            var haberler = new List<News>()
            {
                new News() {NewsTitle="Maymuna aşık olan yaşlı kadın, hayvanat bahçesinden kovuldu",NewsDate=DateTime.Now,NewsDescription="Her hafta Chita'yı kaldığı hayvanat bahçesinde ziyarete eden ve kendisine öpücük yağdıran Adie'nin, yetkililer tarafından hayvanat bahçesine girmesi yasaklanınca yaşlı kadın ülkesinin bir numaralı manşeti oldu.",WriterID=4,NewsStatus=true,ImageUrl="/BlogTECH/upload/b12.jpg",CategoryID=14},

            };

            foreach (var item in haberler)
            {
                context.News.Add(item);
            }
            context.SaveChanges();


            var videolar = new List<Video>()
            {
                new Video() {VideoTitle="SAMSUNG GALAXY A7 2017 ANDROİD 8.0 OREO GÜNCELLEME(TÜRKÇE ANLATIM)",VideoDate=DateTime.Now,VideoDescription="Bu bir orjinal yazılım olduğundan telefonunuzun sayacı artmaz ve garanti dışı kalmaz.",WriterID=4,VideoStatus=true,ImageUrl="/BlogTECH/upload/a12.png",CategoryID=10},

            };

            foreach (var item in videolar)
            {
                context.Videos.Add(item);
            }
            context.SaveChanges();


            var blog = new List<Blog>()
            {
                new Blog() {BlogTitle="MR. ROBOT",BlogDate=DateTime.Now,BlogDescription="Deneme",WriterID=4,BlogStatus=true,ImageUrl="https://miro.medium.com/max/1200/1*VytWprd2ulmw2eIwnHMNJQ.jpeg",CategoryID=6},

            };

            foreach (var item in blog)
            {
                context.Blogs.Add(item);
            }
            context.SaveChanges();

            var admin = new List<AdminUser>()
            {
                new AdminUser() {AdminUserName="admin@gmail.com",AdminRole="A",AdminUserPassword="001",AdminStatus=true,AdminImage="/Image/user.png.png"},
                new AdminUser() {AdminUserName="admin1@gmail.com",AdminRole="B",AdminUserPassword="002",AdminStatus=true,AdminImage="/Image/user.png.png"},
                new AdminUser() {AdminUserName="admin2@gmail.com",AdminRole="A",AdminUserPassword="003",AdminStatus=true,AdminImage="/Image/user.png.png"},

            };

            foreach (var item in admin)
            {
                context.Admins.Add(item);
            }
            context.SaveChanges();


            var writer = new List<WriterUser>()
            {
                new WriterUser() {WriterName="Ali",WriterSurname="Yılmaz",WriterAbout="Yazılım Mühendisi, Frontend Devoloper",WriterTitle="Yazılım Mühendisi",WriterPassword="1",WriterStatus=true,WriterMail="ali@gmail.com",WriterImage="https://image.flaticon.com/icons/png/512/146/146031.png"},
                 new WriterUser() {WriterName="Mehmet",WriterSurname="Çınar",WriterAbout="Senior Software Deweloper , bolca kitap okur",WriterTitle="Kıdemli Geliştirici",WriterPassword="1",WriterStatus=true,WriterMail="mehmet @gmail.com",WriterImage="https://image.flaticon.com/icons/png/512/146/146031.png"},
                  new WriterUser() {WriterName="Emel Öztürk",WriterSurname="Yılmaz",WriterAbout="Tiyatro,Filtre kahve",WriterTitle="Tur Rehberi",WriterPassword="1",WriterStatus=true,WriterMail="emel@gmail.com",WriterImage="https://www.pinclipart.com/picdir/middle/2-28884_png-free-library-file-icons-businesswoman-wikimedia-women.png"},
                   new WriterUser() {WriterName="Ersin",WriterSurname="Bulut",WriterAbout="Spor,Bisiklet,dergiler",WriterTitle="Blogger",WriterPassword="1",WriterStatus=true,WriterMail="ersin@gmail.com",WriterImage="/Image/user.png.png"},
                    new WriterUser() {WriterName="Kamil",WriterSurname="Bulut",WriterAbout="Kahve vazgeçilmezim, yanına bolca kod ile",WriterTitle="Mobil Geliştirici",WriterPassword="1",WriterStatus=true,WriterMail="kamil@gmail.com",WriterImage="https://image.flaticon.com/icons/png/512/146/146031.png"},
            };

            foreach (var item in writer)
            {
                context.Writers.Add(item);
            }
            context.SaveChanges();




            base.Seed(context);
        }
    }
}
