import http from 'k6/http';

export let options = {
    stages: [
        { duration: '2s', target: 10 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 10 },
        
        { duration: '2s', target: 10 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 10 },
        { duration: '2s', target: 10 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 30 },
        { duration: '2s', target: 10 },
        { duration: '2s', target: 10 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<500'], 
    },
};

export default function () {
    http.get("http://213.199.36.5:5001/tasks");
}