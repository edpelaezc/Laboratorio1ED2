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

		public BTree<Bebida, string> myTree = new BTree<Bebida, string>(5);

		public static int CompararBebida(object ob1, object ob2)
		{
			Bebida objeto1 = (Bebida)ob1;
			Bebida objeto2 = (Bebida)ob2;
			return objeto1.nombre.CompareTo(objeto2.nombre);			
		}

		static int buscarBebida(object nombre, object ob) {
			Bebida ob1 = (Bebida)ob;
			string nombreObj = (string)nombre;
			return nombreObj.CompareTo(ob1.nombre);
		}

		public Data() {
			myTree.keyComparer.compareElementsDelegate(CompararBebida);
			myTree.searchElementsDelegate(buscarBebida);
		}

	}

}