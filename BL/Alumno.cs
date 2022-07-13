using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ML;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result(); 

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "INSERT INTO [Alumno] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email])VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = alumno.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct=false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                
            }
            return result;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UPDATE [Alumno] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Email] = @Email WHERE [IdAlumno] = @IdAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = alumno.Email;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "DELETE FROM [Alumno] WHERE IdAlumno= @IdAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct= false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result(); //INSTANCIA ES PARA CREAR OBJETOS QUE ME PERMITAN ACCEDER O MANIPULAR SUS METODOS Y ATRIBUTOS
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = alumno.Email;

                        collection[4] = new SqlParameter("IdSemestre", SqlDbType.Int);
                        collection[4].Value = alumno.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct=false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection  context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoGetAll";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);

                        if(tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alummno = new ML.Alumno();

                                alummno.IdAlumno = int.Parse(row[0].ToString());
                                alummno.Nombre = row[1].ToString();
                                alummno.ApellidoPaterno = row[2].ToString();
                                alummno.ApellidoMaterno = row[3].ToString();
                                alummno.Email = row[4].ToString();

                                alummno.Semestre = new ML.Semestre();
                                alummno.Semestre.IdSemestre = int.Parse(row[5].ToString());

                                result.Objects.Add(alummno);

                            }
                            result.Correct = true;
                            
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdSP(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoGetById";

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        
                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableAlumno);

                        if(tableAlumno.Rows.Count > 0)
                        {
                            DataRow row = tableAlumno.Rows[0];

                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Email = row[4].ToString();

                            alumno.Semestre = new ML.Semestre();

                            alumno.Semestre.IdSemestre = int.Parse(row[5].ToString());

                            result.Object = alumno; //BOXING 

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.AGarciaGenJulioEntities context = new DL_EF.AGarciaGenJulioEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.Semestre.IdSemestre);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result  result=new ML.Result();
            try
            {
                using(DL_EF.AGarciaGenJulioEntities context = new DL_EF.AGarciaGenJulioEntities())
                {
                    var query = context.AlumnoGetAll().ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Email = obj.Email;

                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre =obj.IdSemestre.Value;

                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;   
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AGarciaGenJulioEntities context = new DL_EF.AGarciaGenJulioEntities())
                {
                    var objAlumno = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    if (objAlumno != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = objAlumno.IdAlumno;
                        alumno.Nombre = objAlumno.Nombre;
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.Email = objAlumno.Email;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;

                        result.Object = alumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        
          
    }
}
