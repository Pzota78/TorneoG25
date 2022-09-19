using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {

        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("--------- Menu Torneo ---------");
                Console.WriteLine("1 Insertar Municipio");
                Console.WriteLine("2 Insertar director tecnico");
                Console.WriteLine("3 Insertar Equipo");
                Console.WriteLine("4 Mostrar municipios");
                Console.WriteLine("5 Mostrar directores tecnicos");
                Console.WriteLine("6 Mostrar equipos");
                Console.WriteLine("7 Insertar posicion");
                Console.WriteLine("8 Mostrar posicion");
                Console.WriteLine("9 Insertar jugador");
                Console.WriteLine("10 Mostrar jugador");
                Console.WriteLine("11 Insertar Partido");
                Console.WriteLine("12 Mostrar Partido");
                Console.WriteLine("0 Salir");
                Console.WriteLine("-------------------------------");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {

                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        GetAllMunicipios();
                        break;
                    case 5:
                        GetAllDT();
                        break;
                    case 6:
                        GetAllEquipos();
                        break;
                    case 7:
                        AddPosicion();
                        break;
                    case 8:
                        GetAllPosicion();
                        break;
                    case 9:
                        AddJugador();
                        break;
                    case 10:
                        GetAllJugadores();
                        break;
                    case 11:
                        AddPartido();
                        break;
                    case 12:
                        GetAllPartidos();
                        break;
                }
            } while (opcion != 0);


        }

        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese el nombre del municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);


        }

        private static void AddDT()
        {
            Console.WriteLine("Ingrese el nombre del DT");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento del DT");
            string documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del director tecnico");
            string telefono = Console.ReadLine();
            var directorTecnico = new DirectorTecnico

            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(directorTecnico);
        }
        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese el nombre del equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del DT");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }
        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese el nombre de la posicion");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }
        private static void AddJugador()
        {
            Console.WriteLine("Ingrese el nombre del jugador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id equipo");
            int idEquipo = Int32.Parse(Console.ReadLine());
            
            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
                            
            };
            _repoJugador.AddJugador(jugador, idPosicion, idEquipo);
        }
        
        private static void AddPartido()
        {
            
            Console.WriteLine("Ingrese id equipo local");
            int idEquipoLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese id equipo visitante");
            int idEquipoVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marcador local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marcador visitante");
            int marcadorVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha y hora de partido");
            string fechahora = Console.ReadLine();
            //Console.WriteLine("Fecha" + fechahora.ToString("MMMM dd, yyyy"));


            DateTime dt = new DateTime(2016, 03, 07);
            Console.WriteLine(dt.ToString());
            //object value = String.Format("{0:y yy yyy yyyy}" fechahora = (Console.ReadLine);

            var partido = new Partido
            {
               MarcadorLocal = marcadorLocal,
               MarcadorVisitante = marcadorVisitante, 
               //FechaHora = fechahora,
                            
            };
            _repoPartido.AddPartido(partido, idEquipoLocal, idEquipoVisitante);
        }
        
        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " "+ municipio.Nombre);
            }
        }
        private static void GetAllDT()
        {
            foreach (var directorTecnico in _repoDT.GetAllDT())
            {
                Console.WriteLine(directorTecnico.Id + " "+ directorTecnico.Nombre);
            }
        }
        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Nombre + " " + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre);
            }
        }
        private static void GetAllPosicion()
        {
            foreach (var posicion in _repoPosicion.GetAllPosicion())
            {
                Console.WriteLine(posicion.Id + " "+ posicion.Nombre);
            }
        }
        private static void GetAllJugadores()
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Id +" "+ jugador.Nombre +" "+ jugador.Equipo.Nombre +" "+ jugador.Posicion.Nombre);
            }
        }
        private static void GetAllPartidos()
        {
            foreach (var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(partido.Local.Nombre +" "+  partido.MarcadorLocal +" "+ partido.Visitante.Nombre +" "+ partido.MarcadorVisitante +" "+ partido.FechaHora);
            }
        }
    }
}