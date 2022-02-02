using System;
using System.Collections.Generic;

namespace Word_Search
{
  // https://leetcode.com/problems/word-search/discuss/537036/C-Readable-Dfs
  // https://leetcode.com/problems/word-search/discuss/1507620/C-Simple-to-understand-using-DFS-With-Comments
  // https://www.youtube.com/watch?v=pfiQ_PS1g8E
  class Program
  {
    static void Main(string[] args)
    {
      char[][] board = new char[3][] { new char[] { 'A', 'B', 'C', 'E' }, new char[] { 'S', 'F', 'C', 'S' }, new char[] { 'A', 'D', 'E', 'E' } };
      string word = "ABCCED";
      Program p = new Program();
      Console.WriteLine(p.Exist(board, word));
    }

    public bool Exist(char[][] board, string word)
    {
      int r = board.Length;
      int c = board[0].Length;

      for(int i = 0; i < r; i++)
      {
        for(int j = 0; j < c; j++)
        {
          if (DFS(board, word, i, j, new HashSet<(int, int)>(), 0))
          {
            return true;
          }
        }
      }

      return false;
    }

    bool DFS(char[][] board, string word, int r, int c, HashSet<(int, int)> visited, int idx)
    {
      if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length || visited.Contains((r,c)) || board[r][c] != word[idx]) return false;
      if (idx == word.Length - 1) return true;
      visited.Add((r, c));
      bool result = DFS(board, word, r + 1, c, visited, idx + 1) ||
                    DFS(board, word, r - 1, c, visited, idx + 1) ||
                    DFS(board, word, r, c + 1, visited, idx + 1) ||
                    DFS(board, word, r, c - 1, visited, idx + 1);

      visited.Remove((r, c));
      return result;
    }
  }
}
