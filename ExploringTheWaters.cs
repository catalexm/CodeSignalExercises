/* ************************************************************************************************************
Given a string, find out if its characters can be rearranged to form a palindrome.

Example

For inputString = "aabb", the output should be
palindromeRearranging(inputString) = true.

We can rearrange "aabb" to make "abba", which is a palindrome.

Input/Output

[execution time limit] 3 seconds (cs)

[input] string inputString

A string consisting of lowercase English letters.

Guaranteed constraints:
1 = inputString.length = 50.

[output] boolean

true if the characters of the inputString can be rearranged to form a palindrome, false otherwise.
************************************************************************************************************ */
bool palindromeRearranging(string inputString) {
    var gString = inputString.GroupBy(a => a, (sel, values) => new { sel, values.ToList().Count }).ToList();
    var charImpar =  gString.Count(a => a.Count %2 != 0);
    if(charImpar > 1) return false;
    return true;
}


/* ************************************************************************************************************
You are given an array of integers. On each move you are allowed to increase exactly one of its element by one. 
Find the minimal number of moves required to obtain a strictly increasing sequence from the input.

Example

For inputArray = [1, 1, 1], the output should be
arrayChange(inputArray) = 3.

Input/Output

[execution time limit] 3 seconds (cs)

[input] array.integer inputArray

Guaranteed constraints:
3 = inputArray.length = 105,
-105 = inputArray[i] = 105.

[output] integer

The minimal number of moves needed to obtain a strictly increasing sequence from inputArray.
It's guaranteed that for the given test cases the answer always fits signed 32-bit integer type.
************************************************************************************************************ */
int arrayChange(int[] inputArray) {
    var countmoves = 0;
    for(int i = 1; i < inputArray.Length;i++)
    {
        if(inputArray[i] <= inputArray[i-1])
        {
            var temp = inputArray[i-1] - inputArray[i]+1;
            inputArray[i] += temp;
            countmoves += temp;
        }
    }
    return countmoves;
}

/* ************************************************************************************************************
Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in 
 one of the arrays.

Given two arrays a and b, check whether they are similar.

Example

For a = [1, 2, 3] and b = [1, 2, 3], the output should be
areSimilar(a, b) = true.

The arrays are equal, no need to swap any elements.

For a = [1, 2, 3] and b = [2, 1, 3], the output should be
areSimilar(a, b) = true.

We can obtain b from a by swapping 2 and 1 in b.

For a = [1, 2, 2] and b = [2, 1, 1], the output should be
areSimilar(a, b) = false.

Any swap of any two elements either in a or in b won't make a and b equal.

Input/Output

[execution time limit] 3 seconds (cs)

[input] array.integer a

Array of integers.

Guaranteed constraints:
3 = a.length = 105,
1 = a[i] = 1000.

[input] array.integer b

Array of integers of the same length as a.

Guaranteed constraints:
b.length = a.length,
1 = b[i] = 1000.

[output] boolean

true if a and b are similar, false otherwise.
************************************************************************************************************ */

bool areSimilar(int[] a, int[] b) {
   if (a.SequenceEqual(b)) return true;
    //if(a.Length != b.Length) return false;
    var firstIndex = -1;
    var first = 0;
    for (int aIndex = 0; aIndex < a.Length ; aIndex++)
    {
        if(a[aIndex] != b[aIndex])
        {
            if(first == 0)
            {
                firstIndex = aIndex;
                first++;
            }else if(first < 2)
            {
                //compare with first
                if(b[aIndex] != a[firstIndex]
                   || a[aIndex] != b[firstIndex])
                {
                    return false;
                }
                first++;
            }else
                return false;
        }
    }
    return true;
}

/* ************************************************************************************************************
Given a rectangular matrix of characters, add a border of asterisks(*) to it.

Example

For

picture = ["abc",
           "ded"]
the output should be

addBorder(picture) = ["*****",
                      "*abc*",
                      "*ded*",
                      "*****"]
Input/Output

[execution time limit] 3 seconds (cs)

[input] array.string picture

A non-empty array of non-empty equal-length strings.

Guaranteed constraints:
1 = picture.length = 100,
1 = picture[i].length = 100.

[output] array.string

The same matrix of characters, framed with a border of asterisks of width 1.
************************************************************************************************************ */
string[] addBorder(string[] picture) {
    var frame = new StringBuilder().Insert(0,"*", picture[0].Length + 2).ToString();
    var result = new List<string>() { frame };
    picture.ToList().ForEach(str => result.Add( '*'+str+'*'));
    result.Add(frame);
    return result.ToArray();
}

/* ************************************************************************************************************
Several people are standing in a row and need to be divided into two teams. 
 The first person goes into team 1, the second goes into team 2, the third goes into team 1 again, 
 the fourth into team 2, and so on.

You are given an array of positive integers - the weights of the people. Return an array of two integers, 
 where the first element is the total weight of team 1, and the second element is the total weight of 
 team 2 after the division is complete.

Example

For a = [50, 60, 60, 45, 70], the output should be
alternatingSums(a) = [180, 105].

Input/Output

[execution time limit] 3 seconds (cs)

[input] array.integer a

Guaranteed constraints:
1 = a.length = 105,
45 = a[i] = 100.

[output] array.integer
************************************************************************************************************ */
int[] alternatingSums(int[] a) {
    var frstGroup = a.ToList().Where((value, index) => index % 2 == 0);
    var scndGroup = a.ToList().Where((value, index) => index % 2 != 0);
    return new[] { frstGroup.Sum(), scndGroup.Sum() };
}

/* ************************************************************************************************************
Given a sequence of integers as an array, determine whether it is possible to obtain a strictly increasing 
 sequence by removing no more than one element from the array.

Note: sequence a0, a1, ..., an is considered to be a strictly increasing if a0 < a1 < ... < an. Sequence 
 containing only one element is also considered to be strictly increasing.

Example

For sequence = [1, 3, 2, 1], the output should be
almostIncreasingSequence(sequence) = false.

There is no one element in this array that can be removed in order to get a strictly increasing sequence.

For sequence = [1, 3, 2], the output should be
almostIncreasingSequence(sequence) = true.

You can remove 3 from the array to get the strictly increasing sequence [1, 2]. Alternately, you can 
 remove 2 to get the strictly increasing sequence [1, 3].

Input/Output

[execution time limit] 3 seconds (cs)

[input] array.integer sequence

Guaranteed constraints:
2 = sequence.length = 105,
-105 = sequence[i] = 105.

[output] boolean

Return true if it is possible to remove one element from the array in order to get a strictly increasing 
 sequence, otherwise return false.
************************************************************************************************************ */
bool almostIncreasingSequence(int[] sequence) {
    if(sequence.Length == 2)
    {
        return true;
    }
    for(int i = 2; i < sequence.Length; i++)
    {
        if(sequence[i-2] >= sequence[i-1] && sequence[i-2] < sequence[i])
        {
            return IsIncreasingSequence(sequence.Where((val, idx) => idx != i-1).ToArray());
        }
        if(sequence[i-2] >= sequence[i-1] && sequence[i-2] >= sequence[i])
        {
            return IsIncreasingSequence(sequence.Where((val, idx) => idx != i-2).ToArray());
        }
        if(sequence[i]<= sequence[i-2] && sequence[i] <= sequence[i-1])
        {
            return IsIncreasingSequence(sequence.Where((val, idx) => idx != i).ToArray());        
        }
    }
    return true;
}

bool IsIncreasingSequence(int[] sequence)
{
    for(int i = 1; i < sequence.Length; i++)
    {
        if(sequence[i-1] >= sequence[i]) return false;
    }
    return true;
}
