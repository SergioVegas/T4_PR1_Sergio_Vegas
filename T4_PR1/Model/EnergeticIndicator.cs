using CsvHelper.Configuration.Attributes;

namespace T4_PR1.Model
{
    public class EnergeticIndicator
    {
        [Name("Data")]
        public string Data { get; set; }

        [Name("PBEE_Hidroelectr")]
        public double PBEE_Hidroelectr { get; set; }

        [Name("PBEE_Carbo")]
        public double PBEE_Carbo { get; set; }

        [Name("PBEE_GasNat")]
        public double PBEE_GasNat { get; set; }

        [Name("PBEE_Fuel-Oil")]
        public double PBEE_Fuel_Oil { get; set; }

        [Name("PBEE_CiclComb")]
        public double PBEE_CiclComb { get; set; }

        [Name("PBEE_Nuclear")]
        public double PBEE_Nuclear { get; set; }

        [Name("CDEEBC_ProdBruta")]
        public double CDEEBC_ProdBruta { get; set; }

        [Name("CDEEBC_ConsumAux")]
        public double CDEEBC_ConsumAux { get; set; }

        [Name("CDEEBC_ProdNeta")]
        public double CDEEBC_ProdNeta { get; set; }

        [Name("CDEEBC_ConsumBomb")]
        public double CDEEBC_ConsumBomb { get; set; }

        [Name("CDEEBC_ProdDisp")]
        public double CDEEBC_ProdDisp { get; set; }

        [Name("CDEEBC_TotVendesXarxaCentral")]
        public double CDEEBC_TotVendesXarxaCentral { get; set; }

        [Name("CDEEBC_SaldoIntercanviElectr")]
        public double CDEEBC_SaldoIntercanviElectr { get; set; }

        [Name("CDEEBC_DemandaElectr")]
        public double CDEEBC_DemandaElectr { get; set; }

        [Name("CDEEBC_TotalEBCMercatRegulat")]
        public string? CDEEBC_TotalEBCMercatRegulat { get; set; }

        [Name("CDEEBC_TotalEBCMercatLliure")]
        public string? CDEEBC_TotalEBCMercatLliure { get; set; }

        [Name("FEE_Industria")]
        public string? FEE_Industria { get; set; }

        [Name("FEE_Terciari")]
        public string? FEE_Terciari { get; set; }

        [Name("FEE_Domestic")]
        public string? FEE_Domestic { get; set; }

        [Name("FEE_Primari")]
        public string? FEE_Primari { get; set; }

        [Name("FEE_Energetic")]
        public string? FEE_Energetic { get; set; }

        [Name("FEEI_ConsObrPub")]
        public string? FEEI_ConsObrPub { get; set; }

        [Name("FEEI_SiderFoneria")]
        public string? FEEI_SiderFoneria { get; set; }

        [Name("FEEI_Metalurgia")]
        public string? FEEI_Metalurgia { get; set; }

        [Name("FEEI_IndusVidre")]
        public string? FEEI_IndusVidre { get; set; }

        [Name("FEEI_CimentsCalGuix")]
        public string? FEEI_CimentsCalGuix { get; set; }

        [Name("FEEI_AltresMatConstr")]
        public string? FEEI_AltresMatConstr { get; set; }

        [Name("FEEI_QuimPetroquim")]
        public string? FEEI_QuimPetroquim { get; set; }

        [Name("FEEI_ConstrMedTrans")]
        public string? FEEI_ConstrMedTrans { get; set; }

        [Name("FEEI_RestaTransforMetal")]
        public string? FEEI_RestaTransforMetal { get; set; }

        [Name("FEEI_AlimBegudaTabac")]
        public string? FEEI_AlimBegudaTabac { get; set; }

        [Name("FEEI_TextilConfecCuirCalçat")]
        public string? FEEI_TextilConfecCuirCalsat { get; set; }

        [Name("FEEI_PastaPaperCartro")]
        public string? FEEI_PastaPaperCartro { get; set; }

        [Name("FEEI_AltresIndus")]
        public string? FEEI_AltresIndus { get; set; }

        [Name("DGGN_PuntFrontEnagas")]
        public double DGGN_PuntFrontEnagas { get; set; }

        [Name("DGGN_DistrAlimGNL")]
        public double DGGN_DistrAlimGNL { get; set; }

        [Name("DGGN_ConsumGNCentrTerm")]
        public double DGGN_ConsumGNCentrTerm { get; set; }

        [Name("CCAC_GasolinaAuto")]
        public double CCAC_GasolinaAuto { get; set; }

        [Name("CCAC_GasoilA")]
        public double CCAC_GasoilA { get; set; }

    }
}
