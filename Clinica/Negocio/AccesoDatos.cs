using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Clinica.Dominio
{
    public class AccesoDatos
    {
        //Atributos y Propiedades:
        private SqlConnection _conn;
        private SqlCommand _command;
        private SqlDataReader _reader;
        public SqlDataReader Lector { get { return _reader; } }

        //Constructor:
        public AccesoDatos (string cadenaConexion = "server=.; database = CLINICA_DB; integrated security = true")
        {
            try
            {
                _conn = new SqlConnection (cadenaConexion);
                _conn.Open ();
                _conn.Close ();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //_command = _conn.CreateCommand(); //obs: ver como funciona despues
            _command = new SqlCommand();
        }

        //Metodos:
        //Setear Query
        public void setQuery(string query)
        {
            _command.CommandType = System.Data.CommandType.Text;
            _command.CommandText = query;
        }
        //Setear Stored Procedure
        public void setSP(string query)
        {
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.CommandText = query;
        }
        //Cerrar Conexion
        public void cerrarConexion()
        {
            try
            {
                if (_reader != null)
                    _reader.Close();
                if(_command.Parameters.Count > 0)
                    _command.Parameters.Clear();
                _conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //Cargar el _reader con Datos
        public void ejectuarLectura()
        {
            try
            {
                _command.Connection = _conn;
                _conn.Open ();
                _reader = _command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Ejecutar Query
        public int ejecutarQuery(string query)
        {
            try
            {
                _command.Connection = _conn;
                return _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Setear Parametros
        public void setParametro(string str, object obj)
        {
            _command.Parameters.AddWithValue(str, obj);
        }
        //Liberar Recursos
        public void terminar()
        {
            try
            {
                if(_reader != null)
                    _reader.Close();
                _command.Dispose();
                _conn.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}