using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02EDII.BTree;
using Lab02EDII.Models;

namespace Lab02EDII.Controllers
{
    public class Data
    {
		private static Data instance = null;
		public static Data Instance
		{
			get
			{
				if (instance == null) instance = new Data();
				return instance;
			}
		}

		public BTree<Bebida> myTree = new BTree<Bebida>(5);

		static int CompararBebida(object ob1, object ob2)
		{
			Bebida objeto1 = (Bebida)ob1;
			Bebida objeto2 = (Bebida)ob2;
			return objeto1.nombre.CompareTo(objeto2.nombre);
			//return String.Compare(objeto1.nombre, objeto2.nombre);
		}

		public Data() {
			myTree.keyComparer.compareElementsDelegate(CompararBebida);
			//myTree.root.keyComparer.compareElementsDelegate(CompararBebida);
		}

	}

}