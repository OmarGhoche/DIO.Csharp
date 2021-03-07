using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public Serie getById(int id)
        {
            return listaSerie[id];
        }

        public void Insert(Serie entity)
        {
            listaSerie.Add(entity);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int NextId()
        {
            return listaSerie.Count;
        }

        public void Remove(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Update(int id, Serie entity)
        {
            listaSerie[id] = entity;
        }
    }
}