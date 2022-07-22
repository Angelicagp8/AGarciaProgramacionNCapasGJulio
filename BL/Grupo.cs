using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int IdPlantel)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AGarciaGenJulioEntities context = new DL_EF.AGarciaGenJulioEntities())
                {
                    var query = context.GrupoGetByIdPlantel(IdPlantel).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Grupo grupo = new ML.Grupo();

                            grupo.IdGrupo = obj.IdGrupo;
                            grupo.Nombre = obj.Nombre;
                            grupo.Plantel = new ML.Plantel();
                            grupo.Plantel.IdPlantel = obj.IdPlantel.Value;

                            result.Objects.Add(grupo);
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
    }
}
