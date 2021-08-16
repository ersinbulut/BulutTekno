using BusinessLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class State
    {
        //CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        public StateModelStyle GetModelStyle()
        {
            StateModelStyle models = new StateModelStyle();
            models.toplamkategori = c.Categories.ToList().Count();
            models.basliksayisi = c.Headings.Where(x => x.CategoryID == 17).ToList().Count;
            models.yazarsayisi = c.Writers.Where(x => x.WriterName.Contains("a")).ToList().Count;
            //models.enfbaslik = c.Headings.Where(x=>x.CategoryID) == x.CategoryID ).ToList().Count();
            models.durum = c.Categories.Where(i => i.CategoryStatus == true).ToList().Count();
            models.durum2 = c.Categories.Where(i => i.CategoryStatus == false).ToList().Count();
            models.durum3 = models.durum - models.durum2; 

            return models;
        }
    }
    public class StateModelStyle
    {
        public int toplamkategori { get; set; }
        public int basliksayisi { get; set; }
        public int yazarsayisi { get; set; }
        public int durum { get; set; }
        public int durum2 { get; set; }
        public int durum3 { get; set; }
        

    }
}
