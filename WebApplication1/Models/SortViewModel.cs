namespace WebApplication1.Models;

public class SortViewModel
{
    public SortState SortName { get; set; }
    public SortState SortAge { get; set; }
    public SortState SortCompany { get; set; }
    public SortState Current { get; set; }
    public bool Up { get; set; }

    public SortViewModel(SortState sort)
    {
        SortName = SortState.NameAsc;
        SortAge = SortState.AgeAsc;
        SortCompany = SortState.CompanyAsc;
        Up = true;

        if (sort == SortState.NameDesc || sort == SortState.AgeDesc
            || sort == SortState.CompanyDesc)
        {
            Up = false;
        }

        switch (sort)
        {
            case SortState.NameDesc:
                Current = SortName = SortState.NameAsc;
                break;
            case SortState.AgeAsc:
                Current = SortAge = SortState.AgeDesc;
                break;
            case SortState.AgeDesc:
                Current = SortAge = SortState.AgeAsc;
                break;
            case SortState.CompanyAsc:
                Current = SortCompany = SortState.CompanyDesc;
                break;
            case SortState.CompanyDesc:
                Current = SortCompany = SortState.CompanyAsc;
                break;
            default:
                Current = SortName = SortState.NameDesc;
                break;
        }


    }
}