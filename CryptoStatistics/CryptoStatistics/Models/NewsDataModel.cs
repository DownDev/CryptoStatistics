using System;
using System.Collections.Generic;

namespace CryptoStatistics.Models
{
	public class NewsDataModel
	{
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Post> results { get; set; }
        public string nextPage { get; set; }
    }

    public class Post
    {
        public string title { get; set; }
        public string link { get; set; }
        public List<string> keywords { get; set; }
        public List<string> creator { get; set; }
        public string video_url { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string pubDate { get; set; }
        public string image_url { get; set; }
        public string source_id { get; set; }
        public List<string> category { get; set; }
        public List<string> country { get; set; }
        public string language { get; set; }

        public string cropped_content => content.Substring(0, 150 - title.Length) + "...";
        public int img_size => string.IsNullOrWhiteSpace(image_url) ? 0 : 100;
    }
}

