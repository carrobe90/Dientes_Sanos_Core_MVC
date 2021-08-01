using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Historial.Models
{
    public class MODELO_HISTORIAL
    {

        #region TBL_HISTORIA_CLINICA
        [Key]
        public int HISCLI_ID { get; set; }
        [Required]
        [StringLength(10)]
        public String HISCLI_COD { get; set; }
        [Required]
        [StringLength(10)]
        public String HISCLI_COD_ODONT { get; set; }
        [Required]
        [StringLength(10)]
        public String HISCLI_COD_PAC { get; set; }
        [Required]
        [StringLength(200)]
        public String HISCLI_MOT_CON { get; set; }
        public String HISCLI_ENF_PRO { get; set; }
        public String HISCLI_PRE_ART { get; set; }
        public String HISCLI_FRE_CAR { get; set; }
        public String HISCLI_TEM_COR { get; set; }
        public String HISCLI_FRE_RES { get; set; }
        public String HISCLI_EST { get; set; }
        public String HISCLI_ANT1 { get; set; }
        public String HISCLI_ANT2 { get; set; }
        public String HISCLI_ANT3 { get; set; }
        public String HISCLI_ANT4 { get; set; }
        public String HISCLI_ANT5 { get; set; }
        public String HISCLI_ANT6 { get; set; }
        public String HISCLI_ANT7 { get; set; }
        public String HISCLI_ANT8 { get; set; }
        public String HISCLI_ANT9 { get; set; }
        public String HISCLI_ANT10 { get; set; }
        public String HISCLI_ANT11 { get; set; }
        public String HISCLI_ANT12 { get; set; }
        public String HISCLI_ANT13 { get; set; }
        public String HISCLI_ANT14 { get; set; }
        public String HISCLI_ANT15 { get; set; }
        public String HISCLI_CIE101 { get; set; }
        public String HISCLI_EVOLUCION1 { get; set; }
        public String HISCLI_CIE102 { get; set; }
        public String HISCLI_EVOLUCION2 { get; set; }
        public String HISCLI_CIE103 { get; set; }
        public String HISCLI_EVOLUCION3 { get; set; }
        public String HISCLI_CIE104 { get; set; }
        public String HISCLI_EVOLUCION4 { get; set; }
        public String HISCLI_PRESCRIPCION { get; set; }
        public String HISCLI_OBSERVACIONES { get; set; }
        public byte[] HISCLI_IMG_1 { get; set; }
        public String HISCLI_N_IMG_1 { get; set; }
        public byte[] HISCLI_PDF_1 { get; set; }
        public String HISCLI_N_PDF_1 { get; set; }
        public byte[] HISCLI_IMG_2 { get; set; }
        public String HISCLI_N_IMG_2 { get; set; }
        public byte[] HISCLI_PDF_2 { get; set; }
        public String HISCLI_N_PDF_2 { get; set; }
        public byte[] HISCLI_IMG_3 { get; set; }
        public String HISCLI_N_IMG_3 { get; set; }
        public byte[] HISCLI_IMG_4 { get; set; }
        public String HISCLI_N_IMG_4 { get; set; }
        public byte[] HISCLI_IMG_5 { get; set; }
        public String HISCLI_N_IMG_5 { get; set; }
        public byte[] HISCLI_IMG_6 { get; set; }
        public String HISCLI_N_IMG_6 { get; set; }
        public byte[] HISCLI_IMG_7 { get; set; }
        public String HISCLI_N_IMG_7 { get; set; }
        public byte[] HISCLI_IMG_8 { get; set; }
        public String HISCLI_N_IMG_8 { get; set; }
        public byte[] HISCLI_IMG_9 { get; set; }
        public String HISCLI_N_IMG_9 { get; set; }
        public byte[] HISCLI_IMG_10 { get; set; }
        public String HISCLI_N_IMG_10 { get; set; }
        public byte[] HISCLI_IMG_11 { get; set; }
        public String HISCLI_N_IMG_11 { get; set; }
        public byte[] HISCLI_IMG_12 { get; set; }
        public String HISCLI_N_IMG_12 { get; set; }
        public byte[] HISCLI_IMG_13 { get; set; }
        public String HISCLI_N_IMG_13 { get; set; }
        public byte[] HISCLI_IMG_14 { get; set; }
        public String HISCLI_N_IMG_14 { get; set; }
        public byte[] HISCLI_IMG_15 { get; set; }
        public String HISCLI_N_IMG_15 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HISCLI_FEC_ELA { get; set; }
        [DataType(DataType.Date)]
        public DateTime HISCLI_FEC_ACT { get; set; }
        [Required]
        [StringLength(1)]
        public String HISCLI_EST_ELI { get; set; }



        #endregion

    }
}
