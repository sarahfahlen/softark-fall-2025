namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal) {
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal) {
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (tal == array[mid])
                    return mid;
                
                if (tal < array[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }

        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            //tjekker først om der er plads til nyt tal
            if (next >= sortedArray.Length)
                return sortedArray;

            int newIndex = 0;
            
            //sørger for vi kun kigger på tomme pladser og sammenholder værdien for vores tal og de eksisterende
            while (newIndex < next && sortedArray[newIndex] < tal)
            {
                newIndex++;
            }
            
            //sørger for at rykke alle relevante elementer i array en plads mod højre
            for (int i = next; i > newIndex; i--) {
                sortedArray[i] = sortedArray[i - 1];
            }
            
            //indsætter det nye tal på det rigtige index 
            sortedArray[newIndex] = tal;
            
            //tæller next op
            next++;
            
            return sortedArray;
        }
    }
}