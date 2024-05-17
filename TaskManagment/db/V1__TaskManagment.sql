CREATE TABLE Tasks(
    id SERIAL PRIMARY KEY,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    task VARCHAR (50),
    task_description VARCHAR,
    task_status BOOLEAN
);