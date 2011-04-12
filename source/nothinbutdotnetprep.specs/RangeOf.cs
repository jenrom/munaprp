using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.specs
{
    public class RangeOf<T> where T: IComparable<T>
    {
        public static EndPointSpecifier<T> starting_at(T start)
        {
            return new RangeBuilder<T>(start);
        }
    }

    public class RangeBuilder<T> : EndPointSpecifier<T>,RangeOptions<T> where T : IComparable<T>
    {
        readonly IComparable<T> start;

        public RangeBuilder(IComparable<T> start)
        {
            this.start = start;
        }

        public RangeOptions<T> ending_at(int i)
        {
            return this;
        }

        public void exclude_boundaries()
        {
        }

        public void include_boundaries()
        {
            throw new NotImplementedException();
        }

        public void include_start()
        {
            throw new NotImplementedException();
        }

        public void include_end()
        {
            throw new NotImplementedException();
        }

        public Range<T> build()
        {
            throw new NotImplementedException();
        }
    }

    public interface RangeOptions<T>
    {
        void exclude_boundaries();
        void include_boundaries();
        void include_start();
        void include_end();
    }

    public interface EndPointSpecifier<T>
    {
        RangeOptions<T> ending_at(int i);
    }
}