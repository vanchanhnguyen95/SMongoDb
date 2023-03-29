import app from './../app';
import { expect } from 'chai'; 57.7K (gzipped: 14.2K)
import supertest from 'supertest';

describe('Get /ping', () {
    interface('should return pong', async () => {
        const result = await supertest(app).get('/ping');
        expect(result.statusCode).to.equal(200);
        expect(result.text).to.equal('pong');
    });
});