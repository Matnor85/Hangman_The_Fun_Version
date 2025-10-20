namespace Hangman_The_Fun_Version;
internal class HangManPicture
{
    // Bild animationen för easy som har 8 chanser
    public string[] easyStages = new string[]
{
    // 0 fel
    @"
     ______
          |
          |
          |
          |
          |
    ==========",
    // 1 fel
    @"
     ______
         \|
          |
          |
          |
          |
    ==========",
    // 2 fel
    @"
     ______
     |   \|
          |
          |
          |
          |
    ==========",
    // 3 fel
    @"
     ______
     |   \|
     O    |
          |
          |
          |
    ==========",
    // 4 fel
    @"
     ______
     |   \|
     O    |
     |    |
          |
          |
    ==========",
    // 5 fel
    @"
     ______
     |   \|
     O    |
    /|    |
          |
          |
    ==========",
    // 6 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
          |
          |
    ==========",
    // 7 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
    /     |
          |
    ==========",
    // 8 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
    / \   |
          |
    =========="
};
    // Bild animationen för normal som har 6 chanser
    public string[] normalStages =
        {
    // 0 fel
    @"
     ______
          |
          |
          |
          |
          |
    ==========",
    // 1 fel  
    @"
     ______
     |   \|
     O    |
          |
          |
          |
    ==========",
    // 2 fel
    @"
     ______
     |   \|
     O    |
     |    |
          |
          |
    ==========",
    // 3 fel 
    @"
     ______
     |   \|
     O    |
    /|    |
          |
          |
    ==========",
    // 4 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
          |
          |
    ==========",
    // 5 fel  
    @"
     ______
     |   \|
     O    | 
    /|\   |
    /     |
          |
    ==========",
    // 6 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
    / \   |
          |
    =========="
    };
    // Bild animationen för easy som har 4 chanser
    public string[] hardStages =
        {
    // 0 fel
    @"
     ______
          |
          |
          |
          |
          |
    ==========",
    // 1 fel
    @"
     ______
     |   \|
          |
          |
          |
          |
    ==========",
    // 2 fel
    @"
     ______
     |   \|
     O    |
          |
          |
          |
    ==========",
    // 3 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
          |
          |
    ==========",
    // 4 fel
    @"
     ______
     |   \|
     O    |
    /|\   |
    / \   |
          |
    =========="
    };
}
