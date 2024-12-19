using GestionVols.Models;

public class VolPromotionDecorator : IVolDecorator
{
    private readonly Vol _vol;
    private readonly Offre _offre;

    public VolPromotionDecorator(Vol vol, Offre offre)
    {
        _vol = vol;
        _offre = offre;
    }

    public decimal CalculerPrix(Vol vol)
    {
        return vol.PrixVol - (vol.PrixVol * _offre.PourcentageReduction);
    }
}
