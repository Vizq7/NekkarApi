using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Validation.Models.Local
{
    public class DadesTasques
    {
        public static IList<ModelTasques> tasques { get; private set; }

        static DadesTasques()
        {
            tasques = new ObservableCollection<ModelTasques>
            {
                new ModelTasques
                {
                    Name = "a",
                    Location = "a",
                    Details = "a",
                },
                new ModelTasques
                {
                    Name = "b",
                    Location = "b",
                    Details = "b",
                },
                new ModelTasques
                {
                    Name = "x",
                    Location = "x",
                    Details = "x",
                },
                new ModelTasques
                {
                    Name = "d",
                    Location = "d",
                    Details = "d",
                },
                new ModelTasques
                {
                    Name = "e",
                    Location = "e",
                    Details = "e",
                },
            };
        }

    }
}
