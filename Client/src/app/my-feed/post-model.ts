import { BullBearLevel } from '../models/bull-bear-level';

export interface PostModel {
    postId: number;
    postText: string;
    likeCount: number;
    // dislikeCount: number;
    userId: number;
    userName: string;
    responseToPostId?: number;
    postDate: Date;
    bullBearLevel: BullBearLevel,
    responseCount: number;
}
