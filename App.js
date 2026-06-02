import React, { useState } from "react";

export default function App() {
  const [resume, setResume] = useState(null);
  const [score, setScore] = useState(null);
  const [foundSkills, setFoundSkills] = useState([]);
  const [missingSkills, setMissingSkills] = useState([]);
  const [questions, setQuestions] = useState([]);

  const analyzeResume = async () => {
    if (!resume) {
      alert("Please select a resume");
      return;
    }

    const formData = new FormData();
    formData.append("file", resume);

    const response = await fetch(
      "http://localhost:5111/api/resume/analyze",
      {
        method: "POST",
        body: formData,
      }
    );

    const data = await response.json();

    setScore(data.atsScore);
    setFoundSkills(data.foundSkills);
    setMissingSkills(data.missingSkills);
    setQuestions(data.questions);
  };

  return (
    <div style={{ padding: "40px", fontFamily: "Arial" }}>
      <h1>InterviewSense AI</h1>

      <input
        type="file"
        accept=".pdf"
        onChange={(e) => setResume(e.target.files[0])}
      />

      <br />
      <br />

      <button onClick={analyzeResume}>
        Analyze Resume
      </button>

      {score !== null && (
        <div>
          <h2>ATS Score: {score}%</h2>

          <h3>Found Skills</h3>
          <ul>
            {foundSkills.map((skill, index) => (
              <li key={index}>{skill}</li>
            ))}
          </ul>

          <h3>Missing Skills</h3>
          <ul>
            {missingSkills.map((skill, index) => (
              <li key={index}>{skill}</li>
            ))}
          </ul>

          <h3>Interview Questions</h3>
          <ul>
            {questions.map((q, index) => (
              <li key={index}>{q}</li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}