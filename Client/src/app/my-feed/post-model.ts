import { BullBearLevel } from '../models/bull-bear-level';

export interface PostModel {
    postId: number;
    postText: string;
    likeCount: number;
    userId: number;
    userName: string;
    originalPostId?: number;
    postDate: Date;
    bullBearLevel: BullBearLevel,
    commentCount: number;
    likedByUser: boolean;
}
