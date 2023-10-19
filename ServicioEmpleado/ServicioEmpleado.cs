using ServicioEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioEmpleado : IServicioEmpleado
    {
        public bool ActualizarEmpleado(EmpleadoDC empleado)
        {
            try
            {
                CerveceriaEntities cerveceria = new CerveceriaEntities();


                cerveceria.usp_ActualizarEmpleado(
                    empleado.IDEmpleado, empleado.IDUbigeo, empleado.Nom_empl, empleado.ape_empl, empleado.telefono_empl,
                    empleado.correo_empl, empleado.fec_vencimi_contr_empl, empleado.sexo_empl, empleado.dni_empl, empleado.usu_reg_empl,
                    empleado.estado_empl, empleado.id_ACF
                    );

                cerveceria.SaveChanges();

                return true;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmpleadoDC ConsultarEmpleado(string strCod)
        {
            try
            {
                CerveceriaEntities cerveceria = new CerveceriaEntities();

                EmpleadoDC empleadoDC = new EmpleadoDC();

                TB_Empleado tb_Empleado = (
                    (from miEmpleado in cerveceria.TB_Empleado where miEmpleado.IDEmpleado == strCod select miEmpleado).FirstOrDefault()
                    );

                empleadoDC.IDEmpleado = tb_Empleado.IDEmpleado;
                empleadoDC.IDUbigeo = tb_Empleado.IDUbigeo;
                empleadoDC.Nom_empl = tb_Empleado.Nom_empl;
                empleadoDC.ape_empl = tb_Empleado.ape_empl;
                empleadoDC.fecha_ingreso_empl = Convert.ToDateTime(tb_Empleado.fecha_ingreso_empl);
                empleadoDC.telefono_empl = tb_Empleado.telefono_empl;
                empleadoDC.correo_empl = tb_Empleado.correo_empl;
                empleadoDC.fec_nacimiento_empl = Convert.ToDateTime(tb_Empleado.fec_nacimiento_empl);
                empleadoDC.fec_vencimi_contr_empl = Convert.ToDateTime(tb_Empleado.fec_vencimi_contr_empl);
                empleadoDC.sexo_empl = tb_Empleado.sexo_empl;
                empleadoDC.dni_empl = tb_Empleado.dni_empl;
                empleadoDC.fec_reg_empl = Convert.ToDateTime(tb_Empleado.fec_reg_empl);
                empleadoDC.usu_reg_empl = tb_Empleado.usu_reg_empl;
                empleadoDC.fec_ultm_mod_empl = Convert.ToDateTime(tb_Empleado.fec_reg_empl);
                empleadoDC.usu_ultm_mod_empl = tb_Empleado.usu_ultm_mod_empl;
                empleadoDC.estado_empl = tb_Empleado.estado_empl;
                empleadoDC.Foto = tb_Empleado.Foto;
                empleadoDC.id_ACF = tb_Empleado.id_ACF;



                return empleadoDC;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EliminarEmpleado(string strCod)
        {
            try
            {
                CerveceriaEntities cerveceria = new CerveceriaEntities();

                cerveceria.usp_EliminarEmpleado(strCod);

                cerveceria.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool InsertarEmpleado(EmpleadoDC empleado)
        {
            try
            {
                CerveceriaEntities cerveceria = new CerveceriaEntities();

                cerveceria.usp_InsertarEmpleado(empleado.IDUbigeo, empleado.Nom_empl, empleado.ape_empl,
                    empleado.fecha_ingreso_empl, empleado.telefono_empl, empleado.correo_empl, empleado.fec_nacimiento_empl, empleado.fec_vencimi_contr_empl,
                    empleado.sexo_empl, empleado.dni_empl, empleado.usu_reg_empl, empleado.estado_empl, empleado.Foto, empleado.id_ACF);

                cerveceria.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EmpleadoDC> ListarEmpleado()
        {
            try
            {
                CerveceriaEntities cerveceria = new CerveceriaEntities();

                List<EmpleadoDC> empleados = new List<EmpleadoDC>();

                var query = (from miEmpleado in cerveceria.TB_Empleado orderby miEmpleado.ape_empl select miEmpleado).ToList();

                foreach (var result in query)
                {
                    EmpleadoDC empleadoDC = new EmpleadoDC();

                    empleadoDC.IDEmpleado = result.IDEmpleado;
                    empleadoDC.IDUbigeo = result.IDUbigeo;
                    empleadoDC.Nom_empl = result.Nom_empl;
                    empleadoDC.ape_empl = result.ape_empl;
                    empleadoDC.fecha_ingreso_empl = Convert.ToDateTime(result.fecha_ingreso_empl);
                    empleadoDC.telefono_empl = result.telefono_empl;
                    empleadoDC.correo_empl = result.correo_empl;
                    empleadoDC.fec_nacimiento_empl = Convert.ToDateTime(result.fec_nacimiento_empl);
                    empleadoDC.fec_vencimi_contr_empl = Convert.ToDateTime(result.fec_vencimi_contr_empl);
                    empleadoDC.sexo_empl = result.sexo_empl;
                    empleadoDC.dni_empl = result.dni_empl;
                    empleadoDC.fec_reg_empl = Convert.ToDateTime(result.fec_reg_empl);
                    empleadoDC.usu_reg_empl = result.usu_reg_empl;
                    empleadoDC.fec_ultm_mod_empl = Convert.ToDateTime(result.fec_reg_empl);
                    empleadoDC.usu_ultm_mod_empl = result.usu_ultm_mod_empl;
                    empleadoDC.estado_empl = result.estado_empl;
                    //empleadoDC.Foto = result.Foto;
                    empleadoDC.id_ACF = result.id_ACF;

                    empleados.Add(empleadoDC);
                }

                return empleados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
