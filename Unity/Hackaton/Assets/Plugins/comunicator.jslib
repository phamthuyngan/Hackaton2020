mergeInto(LibraryManager.library,{
 LevelData: function(pseudo, score) {
    localStorage.setItem(pseudo, score);
 },
});