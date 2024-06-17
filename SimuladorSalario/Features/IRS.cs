namespace PortugalSalarySimulator.Features;

public enum IRS_Scale
{
  Null,
  First,
  Second,
  Third,
  Fourth,
  Fifth,
  Sixth,
  Senventh,
  Eighth,
  Nineth
}
public class IRS_Config
{
  public IRS_Scale Scale { get; set; }
  public decimal ParcelaAbater { get; set; }
  public decimal Tax { get; set; }
}

public class IRS
{
  


  public static IRS_Scale GetIrsScale(decimal val, bool divideScale, int dependents)
  {
    if (divideScale)
    {
      var divisor = divideScale ? 2 : 1;
      divisor += dependents;
      val = val / divisor;
    }

    if (val <= 7479m)
    {
      return (IRS_Scale) 1;
    }

    if (val > 7479m && val <= 11284m)
    {
      return (IRS_Scale) 2;
    }

    if (val > 11284m && val <= 15992m)
    {
      return (IRS_Scale) 3;
    }

    if (val > 15992m && val <= 20700m)
    {
      return (IRS_Scale) 4;
    }

    if (val > 20700m && val <= 26355m)
    {
      return (IRS_Scale) 5;
    }

    if (val > 26355m && val <= 38632m)
    {
      return (IRS_Scale) 6;
    }

    if (val > 38632m && val <= 50483m)
    {
      return (IRS_Scale) 7;
    }

    if (val > 50483m && val <= 78834m)
    {
      return (IRS_Scale) 8;
    }

    if (val > 78834m)
    {
      return (IRS_Scale) 9;
    }

    return IRS_Scale.Null;
  }
      public static List<IRS_Config> Configs = new List<IRS_Config>()
      {
        new()
        {
          Scale = IRS_Scale.First,
          ParcelaAbater = 0m,
          Tax = 14.5m
        },
        new()
        {
          Scale = IRS_Scale.Second,
          ParcelaAbater = 486.14m,
          Tax = 21m
        },
        new()
        {
          Scale = IRS_Scale.Third,
          ParcelaAbater = 1106.73m,
          Tax = 26.5m
        },
        new()
        {
          Scale = IRS_Scale.Fourth,
          ParcelaAbater = 1426.65m,
          Tax = 28.5m
        },
        new()
        {
          Scale = IRS_Scale.Fifth,
          ParcelaAbater = 2772.14m,
          Tax = 35m
        },
        new()
        {
          Scale = IRS_Scale.Sixth,
          ParcelaAbater = 3_299.12m,
          Tax = 37m
        },
        new()
        {
          Scale = IRS_Scale.Senventh,
          ParcelaAbater = 5_810.25m,
          Tax = 43.5m
        },
        new()
        {
          Scale = IRS_Scale.Eighth,
          ParcelaAbater = 6567.33m,
          Tax = 45m
        },
        new()
        {
          Scale = IRS_Scale.Nineth,
          ParcelaAbater = 8_932.68m,
          Tax = 48m
        },
      };
}