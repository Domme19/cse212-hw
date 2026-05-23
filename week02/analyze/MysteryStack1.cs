public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

// racecar
//  in the stack
// ["r", "a", "c", "e", "c", "a", "r"]
// pop () ====> at the end of the array"
// length = 10, 
//  we check if the stack is not empty
// then pop() means taking object at the current index, and decreasing index
// we are just moving the index down and updating the  COUNT
// result = "" will be concatenating with r a ce car


// output for racecar = racecar
// output for stressed = desserts
//  output for a nut for a jar of tuna = anut fo raj a rof tun a