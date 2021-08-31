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



            base.Seed(context);
        }
    }
}
