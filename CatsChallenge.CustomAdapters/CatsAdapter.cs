using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using CatsChallenge.Entities;

namespace CatsChallenge.CustomAdapters
{
    public class CatsAdapter : BaseAdapter<Cat>
    {
        List<Cat> Items; // Datos de cada evidencia de laboratorio.
        Activity Context; // Activity donde se utilizará este Adapter.
        int ItemLayoutTemplate; // Layout a utilizar para mostrar los datos de un elemento.
        int CatNameViewID; // ID del TextView donde se mostrará el nombre del Gato.
        int CatPriceViewID; // ID del TextView donde se mostrará el precio del Gato.
        int CatImageViewID; // ID del ImageView donde se mostrará la foto del Gato.
                            /// <summary>
                            /// Constructor para recibir la información que necesita el Adapter
                            /// </summary>
                            /// <param name="context">Activity donde se aloja el ListView.</param>
                            /// <param name="cats">La lista de elementos.</param>
                            /// <param name="itemLayoutTemplate">ID del Layout para mostrar cada elemento del ListView.</param>
                            /// <param name="catNameViewID">ID del TextView donde se mostrará el nombre del Gato.</param>
                            /// <param name="catPriceViewID">ID del TextView donde se mostrará el precio del Gato.</param>
                            /// <param name="catImageViewID">ID del ImageView donde se mostrará la foto del Gato.</param>

        public CatsAdapter(Activity context, List<Cat> cats, int itemLayoutTemplate, int catNameViewID, int catPriceViewID, int catImageViewID)
        {
            this.Context = context;
            this.Items = cats;
            this.ItemLayoutTemplate = itemLayoutTemplate;
            this.CatNameViewID = catNameViewID;
            this.CatPriceViewID = catPriceViewID;
            this.CatImageViewID = catImageViewID;
        }

        /// <summary>
        /// Devuelve el elemento de la lista localizado en la posición especificada.
        /// </summary>
        /// <param name="position">Posición del elemento dentro de la lista.</param>
        /// <returns></returns>
        public override Cat this[int position]
        {
            get
            {
                return Items[position];
            }
        }

        /// <summary>
        /// Devuelve el número de elementos de la lista.
        /// </summary>
        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }
        /// <summary>
        /// Devuelve el ID del elemento localizado en la posición especificada.
        /// </summary>
        /// <param name="position">Posición del elemento dentro de la lista.</param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return Items[position].ID;
        }
        //
        /// <summary>
        /// Devuelve el View que muestra los datos de un elemento del conjunto de datos.
        /// </summary>
        /// <param name="position">Posición del elemento a mostrar.</param>
        /// <param name="convertView">View anterior que puede ser reutilizada.</param>
        /// <param name="parent">View padre al que podria adjuntarse el View devuelto.</param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Obtenemos el elemento del cual se requiere la Vista
            var Item = Items[position];
            View ItemView; // Vista que vamos a devolver
            if (convertView == null)
            {
                // No hay vista reutilizable, crear una nueva
                ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null /* No hay View padre*/);
            }
            else
            {
                // Reutilizamos un View existente para ahorrar recursos
                ItemView = convertView;
            }
            // Establecemos los datos del elemento dentro del View
            ItemView.FindViewById<TextView>(CatNameViewID).Text = Item.Name;
            //Formato de Moneda C2
            ItemView.FindViewById<TextView>(CatPriceViewID).Text = Item.Price.ToString("C2");

            var imageViewCat = ItemView.FindViewById<ImageView>(CatImageViewID);

            Koush.UrlImageViewHelper.SetUrlDrawable(imageViewCat, Item.Image);

            //Android.Net.Uri URI = Android.Net.Uri.Parse(Item.Image); 

            //ItemView.FindViewById<ImageView>(CatImageViewID).SetImageURI(URI);

            return ItemView;
        }
    }
}