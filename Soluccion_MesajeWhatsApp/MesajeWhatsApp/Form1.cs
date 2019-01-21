using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//alumno de Ing. en Informatica Jimmy Meneses
namespace MesajeWhatsApp
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {//para enviar mensaje en nice api debes registrar el numero en la api o pagina de nice api

            //id dada por niceApi, para conectarlos a ella
            string id_api = "CK0NRnybG0G2ZiO8VBXQg2ppbW15bWVuZXNlczExX2F0X2dtYWlsX2RvdF9jb20=";
            string numero = "+56974015393";//numero de telefono que enviaremos el mensaje por Whatsapp 
            string mensaje = txtMensaje.Text;//txt donde se escribira el mensaje

            if (mensaje==null)//validación si no hay mensaje no enviara nada
            {
                MessageBox.Show("No se ha enviado el Mensaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //mensaje de advertencia que nos enviara el mensaje.
            }
            else
            {
                try
                {//preguntamos si desea enviar ese mensaje
                    DialogResult resul = MessageBox.Show("¿Seguro que quiere enviar el mensaje?", "Enviar mensaje", MessageBoxButtons.YesNo);
                    if (resul == DialogResult.Yes)
                    {
                        //atributos 
                        string url = "https://niceapi.net/API";//direccion de la api
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//capturamos la url de la api para conectarnos
                        request.Method = "POST";//metodo utilizado
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.Headers.Add("X-APIId", id_api);
                        request.Headers.Add("X-APIMobile", numero);
                        using (System.IO.StreamWriter stream = new System.IO.StreamWriter(request.GetRequestStream()))
                        {
                            stream.Write(mensaje);//capturamos el mensaje que se enviara
                        }
                        using (System.IO.StreamReader write = new System.IO.StreamReader(request.GetResponse().GetResponseStream()))
                        {
                            Console.WriteLine(write.ReadToEnd());//enviamos el mensaje
                        }
                        //mensaje de exito
                        MessageBox.Show("El mensaje ha sido enviado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMensaje.Clear();
                    }

                }
                catch (SystemException ji)
                {
                    //excepcion capturada
                    Console.WriteLine(ji.Message);
                }

                Console.ReadLine();
            }
        }

        }
    }

