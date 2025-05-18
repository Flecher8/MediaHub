using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Core.Services.Abstract;
public interface IAnimeImportService
{
    Task ImportFromStreamAsync(Stream jsonStream);
}
