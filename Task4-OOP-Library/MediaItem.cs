class MediaItem{
    public string Title{ get; set;}
    public string MediaType{ get; set;}
    public int Duration{ get; set;}

    public MediaItem(string title, string mediaType, int duration){
        Title=title;
        MediaType=mediaType;
        Duration=duration;
    }
    public override string ToString(){
        return $"Title: {Title}, Type: {MediaType}, Duration (minutes): {Duration}";
    }

}