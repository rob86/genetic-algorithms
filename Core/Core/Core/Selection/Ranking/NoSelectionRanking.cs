using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    public class NoSelectionRanking : ISelectionRanking
    {
        private IChromosome[] Population
        {
            get;
            set;
        }
        private Double TotalFitness
        {
            get;
            set;
        }
        public void SetPopulation(IChromosome[] population)
        {
            Population = (IChromosome[])population.Clone();
            TotalFitness = Population.Sum(chromosome => chromosome.Evaluate());
        }
        public Double GetRank(Int32 index)
        {
            return Population[index].Evaluate() / TotalFitness;
        }
        public IChromosome GetChromosome(Int32 index)
        {
            return Population[index];
        }
    }
}
