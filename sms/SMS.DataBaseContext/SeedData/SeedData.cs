using Microsoft.EntityFrameworkCore;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DataBaseContext.SeedData
{
    public static class SeedData
    {
        public static void SeedDatas(ModelBuilder builder)
        {
            builder.Entity<Divison>().HasData(
                new Divison {Id=1, Code = "001D", Name = "Dhaka" },
                new Divison {Id=2, Code = "002D", Name = "Khulna" }
                );
            builder.Entity<District>().HasData(
               new District { Id = 1, Code = "001Di", Name = "Kishoreganj", DivisonId=1 },
               new District { Id = 2, Code = "002Di", Name = "Gazipur", DivisonId = 1 },
               new District { Id = 3, Code = "003Di", Name = "Manikganj", DivisonId = 1 },
                new District { Id = 4, Code = "004Di", Name = "Jessore", DivisonId = 2 },
               new District { Id = 5, Code = "005Di", Name = "Narail", DivisonId = 2 }
               );
            builder.Entity<Upazila>().HasData(
              new Upazila { Id = 1, Code = "001U", Name = "Kishoreganj Sadar", DistrictId=1 },
              new Upazila { Id = 2, Code = "002U", Name = "Bhairab", DistrictId = 1 },
              new Upazila { Id = 3, Code = "003U", Name = "Bajitpur", DistrictId = 1 },
              new Upazila { Id = 4, Code = "004U", Name = "Kuliarchar", DistrictId = 1 },
              new Upazila { Id = 5, Code = "005U", Name = "Pakundia", DistrictId = 1 },
              new Upazila { Id = 6, Code = "006U", Name = "Itna", DistrictId = 1 },
              new Upazila { Id = 7, Code = "007U", Name = "Karimganj", DistrictId = 1 },
              new Upazila { Id = 8, Code = "008U", Name = "Katiadi", DistrictId = 1 },
              new Upazila { Id = 9, Code = "009U", Name = "Ashtagram", DistrictId = 1 },
              new Upazila { Id = 10, Code = "0010U", Name = "Mithamin", DistrictId = 1 },
              new Upazila { Id = 11, Code = "0011U", Name = "Tarail", DistrictId = 1 },
              new Upazila { Id = 12, Code = "0012U", Name = "Hossainpur", DistrictId = 1 },
              new Upazila { Id = 13, Code = "0013U", Name = "Nikli", DistrictId = 1 },
               new Upazila { Id = 14, Code = "0014U", Name = "Lohagara", DistrictId = 4 },
              new Upazila { Id = 15, Code = "0014U", Name = "Jigorgacha", DistrictId = 5 },
              new Upazila { Id = 16, Code = "0016U", Name = "Kalia", DistrictId = 4 }
              );
        }
    }
}
