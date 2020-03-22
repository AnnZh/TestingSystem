using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Domain.Tests
{
    public class GroupOfTests
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
