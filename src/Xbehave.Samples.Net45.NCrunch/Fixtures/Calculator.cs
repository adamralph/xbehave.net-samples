// <copyright file="Calculator.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples.Fixtures
{
    using System.Threading.Tasks;

    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public async Task<int> AddAsync(int x, int y)
        {
            return await Task.FromResult(x + y);
        }

        public void CoolDown()
        {
        }
    }
}
