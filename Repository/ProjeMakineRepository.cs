using System;
using System.Collections.Generic;
using System.Data;
using EMAR.Helpers;
using EMAR.Models;

namespace EMAR.Repository
{
    public static class ProjeMakineRepository
    {
        public static List<Makine> GetirTumMakineler()
        {
            var dt = VeritabaniHelper.TabloGetir("SELECT Id, Ad FROM Makineler");
            var liste = new List<Makine>();

            foreach (DataRow r in dt.Rows)
            {
                liste.Add(new Makine
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Ad = r["Ad"].ToString()
                });
            }

            return liste;
        }

        public static List<Makine> GetirProjeyeAitMakineler(int projeId)
        {
            var dt = VeritabaniHelper.TabloGetir(
                "SELECT M.Id, M.Ad FROM ProjeMakineleri PM JOIN Makineler M ON M.Id = PM.MakineId WHERE PM.ProjeId = @pid",
                new() { ["@pid"] = projeId });

            var liste = new List<Makine>();
            foreach (DataRow r in dt.Rows)
            {
                liste.Add(new Makine
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Ad = r["Ad"].ToString()
                });
            }
            return liste;
        }

        public static void Ekle(int projeId, int makineId)
        {
            VeritabaniHelper.KomutCalistir(
                "INSERT OR IGNORE INTO ProjeMakineleri (ProjeId, MakineId) VALUES (@pid, @mid)",
                new() { ["@pid"] = projeId, ["@mid"] = makineId });
        }

        public static void Cikar(int projeId, int makineId)
        {
            VeritabaniHelper.KomutCalistir(
                "DELETE FROM ProjeMakineleri WHERE ProjeId = @pid AND MakineId = @mid",
                new() { ["@pid"] = projeId, ["@mid"] = makineId });
        }
    }
}