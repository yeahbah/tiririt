export interface NewsRss {
    rss: IRssObject;
  }
  
  export interface IRssObject {
    $: any;
    channel: IRssChannel;
  }
  
  export interface IRssChannel {
    "atom:link"?: string;
    description?: string;
    // image: Array<IRssImage>;
    item: IRssItem[];
    // language: Array<string>;
    // lastBuildDate: Date;
    generator: string;
    link: string;
    title: string;
  }
  
  export interface IRssImage {
    link: string;
    title: string;
    url: string;
  }
  
  export interface IRssItem {
    // category: Array<string>;
    description: string;
    guid: any;
    link: string;
    pubDate: string;
    title: string;
  }
  