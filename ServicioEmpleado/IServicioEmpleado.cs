using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioEmpleado
    {
        [OperationContract]
        Boolean ActualizarEmpleado(EmpleadoDC empleado);
        
        [OperationContract]
        Boolean InsertarEmpleado(EmpleadoDC empleado);
        
        [OperationContract]
        Boolean EliminarEmpleado(string strCod);


        [OperationContract]
        EmpleadoDC ConsultarEmpleado(String strCod);

        [OperationContract]
        List<EmpleadoDC> ListarEmpleado();



        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "ServicioEmpleado.ContractType".
    [Serializable]
    [DataContract]
    public class EmpleadoDC
    {

        [DataMember]

        public string IDEmpleado { get; set; }

        [DataMember]

        public string IDUbigeo { get; set; }

        [DataMember]
        public string Nom_empl { get; set; }

        [DataMember]
        public string ape_empl { get; set; }
        
        [DataMember]
        public DateTime fecha_ingreso_empl { get; set; }
        
        [DataMember]
        public string telefono_empl { get; set; }
        
        [DataMember]
        public string correo_empl { get; set; }


        [DataMember]
        public DateTime fec_nacimiento_empl { get; set; }


        [DataMember]
        public DateTime fec_vencimi_contr_empl { get; set; }


        [DataMember]
        public string sexo_empl { get; set; }


        [DataMember]
        public string dni_empl { get; set; }


        [DataMember]
        public DateTime fec_reg_empl { get; set; }


        [DataMember]
        public string usu_reg_empl { get; set; }


        [DataMember]
        public DateTime fec_ultm_mod_empl { get; set; }


        [DataMember]
        public string usu_ultm_mod_empl { get; set; }


        [DataMember]
        public string estado_empl { get; set; }


        [DataMember]
        public byte[] Foto { get; set; }


        [DataMember]
        public string id_ACF { get; set; }


    }
}
