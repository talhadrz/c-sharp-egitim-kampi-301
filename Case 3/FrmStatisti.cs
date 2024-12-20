using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpEgitimKampi301.EntityLayer.EFProject
{
    public partial class FrmStatisti : Form
    {
        public FrmStatisti()
        {
            InitializeComponent();
        }
        egitimkampiEfTravelDbEntities db = new egitimkampiEfTravelDbEntities();
        private void FrmStatisti_Load(object sender, EventArgs e)
        {
            
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacty.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
           lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice).ToString()+"TL";
            int lastCountryıd = db.Location.Max(x=>x.Locationıd);
            lblaLastCountryName.Text = db.Location.Where(x => x.Locationıd == lastCountryıd).Select(x => x.LocationCountry).FirstOrDefault();
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();
            var romeGuideId = db .Location.Where(x => x.LocationCity == "Roma Turist").Select(y=>y.Guideıd).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.Guideıd == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCountry).FirstOrDefault().ToString();
            var maxPrice = db.Location.Max(x=>x.LocationPrice);
            lblMaxPriceLocatin.Text = db.Location.Where(X => X.LocationPrice == maxPrice).Select(Y => Y.LocationCountry).FirstOrDefault().ToString();
            var guideIdByAysegulcinar = db.Guide.Where(x => x.GuideName == "Ayşegül" & x.GuideSurname == "Çınar").Select(y => y.Guideıd).FirstOrDefault();
            lblAysegulCınarLocation.Text = db.Location.Where(x=> x.Guideıd == guideIdByAysegulcinar).Count().ToString();

        }
    }
}
