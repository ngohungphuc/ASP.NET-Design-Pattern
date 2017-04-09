using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Models
{
    /// <summary>
    /// Main class for application model
    /// </summary>
    public abstract class BaseEntity : BaseEntityWithTypeId<int>
    {
    }
}