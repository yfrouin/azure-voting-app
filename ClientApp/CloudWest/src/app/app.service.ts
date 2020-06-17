import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vote } from './models/vote.model';

@Injectable()
export class AppService {
  public functionsUrl: string;
  public eventName: string;

  constructor(private http: HttpClient) {}

  async getVotes(): Promise<Vote[]> {
    try {
      return await this.http
        .get<Vote[]>(`${this.functionsUrl}vote/${this.eventName}`)
        .toPromise();
    } catch (e) {
      console.error('Failed to get Votes');
      throw e;
    }
  }

  async createVote(leftSide: string, rightSide: string): Promise<any> {
    try {
      const newVote: Vote = {
        eventName: this.eventName,
        leftSide: leftSide,
        rightSide: rightSide,
      };
      return await this.http
        .post(`${this.functionsUrl}vote`, newVote)
        .toPromise();
    } catch (e) {
      console.error('Failed to create new Vote');
      throw e;
    }
  }

  async addVote(voteId: string,side: string): Promise<any> {
    try {
      return await this.http
        .put(`${this.functionsUrl}vote/${this.eventName}/${voteId}/${side}`, {})
        .toPromise();
    } catch (e) {
      console.error(`Failed to add a vote for the ${side} side of vote with identifier ${voteId}`);
      throw e;
    }
  }
}
