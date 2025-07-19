using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model;
public class NavMenuData
{
    public string Application { get; set; }
    public string Título { get; set; }
    public Linkbase LinkBase { get; set; }
    public Link[] Links { get; set; }
    public string Permission { get; set; }
}

public class Linkbase
{
    public string linkDev { get; set; }
    public string linkProduction { get; set; }
}

public class Link
{
    public string Name { get; set; }
    public string LinkNavigation { get; set; }
    public string Permission { get; set; }
}
