using System.Collections.Generic;
using System.Linq;
using Files;

namespace QueriedData
{
    public record SpeciesStats(string SpeciesName, double AverageSepalLength, double MinPetalLength);

    public class IrisQueries
    {
        List<Iris> _allData;
        FileReader fileReader = new FileReader();
        /*
        practice writing singleton with this constructor.
        why not set this class as static and the methods too?
        how do static classes look like on the memory heap(or is it even heap?)? 
        how is the number of instances controlled for them ?
        */
        public IrisQueries()
        {
            _allData = fileReader.GetIrises();
        }
        public List<Iris> GetIrisesBySpeciesName(string speciesName)
        {
           return _allData.Where(spec => spec.Species == speciesName).ToList();
        }

        public List<SpeciesStats> GetStatsPerSpecies(){
           return _allData.GroupBy(spec=>spec.Species).Select(x=> new SpeciesStats(
                SpeciesName: x.Key,
                AverageSepalLength: x.Average(iris=>iris.SepalLength),
                MinPetalLength: x.Min(iris => iris.PetalLength)
           )).ToList();
        }
    
    }
}
