
import { Chess } from "https://cdn.jsdelivr.net/npm/chess.js@1.4.0/dist/esm/chess.js";

const game = new Chess();

const board = document.getElementById("chessBoard");
const status = document.getElementById("gameStatus");
const historyElement = document.getElementById("moveHistory");

const whiteName = document.getElementById("whiteName");
const blackName = document.getElementById("blackName");

const glyphs = {
    wk: "♔", wq: "♕", wr: "♖", wb: "♗", wn: "♘", wp: "♙",
    bk: "♚", bq: "♛", br: "♜", bb: "♝", bn: "♞", bp: "♟"
};

let selected = null;
let possibleMoves = [];
let lastMove = null;
let resultSaved = false;

let scores = JSON.parse(
    localStorage.getItem("chessScores") || "null"
) || {
    whiteWins: 0,
    blackWins: 0,
    draws: 0,
    whitePoints: 0,
    blackPoints: 0
};

function saveScores() {
    localStorage.setItem("chessScores", JSON.stringify(scores));
    updateScores();
}

function updateScores() {
    document.getElementById("whitePoints").textContent =
        scores.whitePoints.toFixed(1);

    document.getElementById("blackPoints").textContent =
        scores.blackPoints.toFixed(1);

    document.getElementById("whiteWins").textContent =
        scores.whiteWins;

    document.getElementById("blackWins").textContent =
        scores.blackWins;

    document.getElementById("draws").textContent =
        scores.draws;

    document.getElementById("totalGames").textContent =
        scores.whiteWins + scores.blackWins + scores.draws;

    document.getElementById("whiteStats").textContent =
        scores.whiteWins + " victorias";

    document.getElementById("blackStats").textContent =
        scores.blackWins + " victorias";
}

function getName(color) {
    return color === "w"
        ? whiteName.value.trim() || "Jugador 1"
        : blackName.value.trim() || "Jugador 2";
}

function renderBoard() {
    board.innerHTML = "";

    const position = game.board();

    position.forEach((row, rowIndex) => {
        row.forEach((piece, colIndex) => {
            const squareName =
                "abcdefgh"[colIndex] + (8 - rowIndex);

            const square = document.createElement("div");

            square.className =
                "square " +
                ((rowIndex + colIndex) % 2 === 0
                    ? "light" : "dark");

            square.dataset.square = squareName;

            if (selected === squareName) {
                square.classList.add("selected");
            }

            if (
                lastMove &&
                (lastMove.from === squareName ||
                    lastMove.to === squareName)
            ) {
                square.classList.add("last-move");
            }

            if (possibleMoves.some(m => m.to === squareName)) {
                const capture = possibleMoves.some(
                    m => m.to === squareName && m.captured
                );

                square.classList.add(capture ? "capture" : "possible");
            }

            if (piece) {
                const span = document.createElement("span");
                span.className =
                    "piece " +
                    (piece.color === "w" ? "white-piece" : "black-piece");

                span.textContent = glyphs[piece.color + piece.type];
                square.appendChild(span);
            }

            square.addEventListener("click", () => {
                handleSquare(squareName);
            });

            board.appendChild(square);
        });
    });
}

function handleSquare(square) {
    if (game.isGameOver()) return;

    const piece = game.get(square);

    if (selected) {
        const move = possibleMoves.find(m => m.to === square);

        if (move) {
            playMove(selected, square);
            return;
        }
    }

    if (piece && piece.color === game.turn()) {
        selected = square;
        possibleMoves = game.moves({
            square: square,
            verbose: true
        });

        renderBoard();
        return;
    }

    selected = null;
    possibleMoves = [];
    renderBoard();
}

function playMove(from, to) {
    try {
        const movingPiece = game.get(from);
        let promotion = "q";

        if (
            movingPiece &&
            movingPiece.type === "p" &&
            (to[1] === "8" || to[1] === "1")
        ) {
            const choice = prompt(
                "¿En qué pieza deseas convertir el peón? Escribe q, r, b o n.",
                "q"
            );

            if (choice === null) return;

            promotion = choice.toLowerCase();

            if (!["q", "r", "b", "n"].includes(promotion)) {
                alert("Opción incorrecta. Se convertirá en dama.");
                promotion = "q";
            }
        }

        const move = game.move({
            from,
            to,
            promotion
        });

        if (!move) return;

        lastMove = { from: move.from, to: move.to };
        selected = null;
        possibleMoves = [];

        renderHistory();
        renderBoard();
        updateStatus();
        checkResult();

    } catch (error) {
        console.error(error);
        alert("No se pudo realizar el movimiento.");
    }
}

function renderHistory() {
    const moves = game.history();

    if (!moves.length) {
        historyElement.textContent = "Todavía no hay movimientos.";
        return;
    }

    historyElement.innerHTML = "";

    for (let i = 0; i < moves.length; i += 2) {
        const row = document.createElement("div");
        row.className = "move-row";

        const number = document.createElement("strong");
        number.textContent = (Math.floor(i / 2) + 1) + ".";

        const white = document.createElement("span");
        white.textContent = moves[i];

        const black = document.createElement("span");
        black.textContent = moves[i + 1] || "—";

        row.append(number, white, black);
        historyElement.appendChild(row);
    }

    historyElement.scrollTop = historyElement.scrollHeight;
}

function updateStatus() {
    if (game.isCheckmate()) {
        const winner = game.turn() === "w" ? "negras" : "blancas";
        status.textContent = "¡Jaque mate! Ganan las " + winner + ".";
        return;
    }

    if (game.isDraw()) {
        status.textContent = "Partida empatada.";
        return;
    }

    const player = getName(game.turn());

    status.textContent = player + " (" +
        (game.turn() === "w" ? "blancas" : "negras") +
        ") debe jugar." +
        (game.isCheck() ? " ¡JAQUE!" : "");
}

function checkResult() {
    if (!game.isGameOver() || resultSaved) return;

    resultSaved = true;

    if (game.isCheckmate()) {
        if (game.turn() === "w") {
            scores.blackWins++;
            scores.blackPoints += 1;
            alert("¡Jaque mate! Gana " + getName("b"));
        } else {
            scores.whiteWins++;
            scores.whitePoints += 1;
            alert("¡Jaque mate! Gana " + getName("w"));
        }
    } else {
        scores.draws++;
        scores.whitePoints += 0.5;
        scores.blackPoints += 0.5;
        alert("¡La partida terminó en empate!");
    }

    saveScores();
}

function resetGame() {
    game.reset();
    selected = null;
    possibleMoves = [];
    lastMove = null;
    resultSaved = false;

    renderBoard();
    renderHistory();
    updateStatus();
}

document.getElementById("undoButton").addEventListener("click", () => {
    if (resultSaved) {
        alert("La partida ya terminó. Inicia una nueva partida.");
        return;
    }

    const move = game.undo();

    if (move) {
        selected = null;
        possibleMoves = [];
        lastMove = null;

        const history = game.history({ verbose: true });

        if (history.length) {
            const previous = history[history.length - 1];
            lastMove = {
                from: previous.from,
                to: previous.to
            };
        }

        renderBoard();
        renderHistory();
        updateStatus();
    }
});

document.getElementById("restartButton").addEventListener("click", () => {
    if (confirm("¿Quieres reiniciar esta partida?")) {
        resetGame();
    }
});

document.getElementById("newGameButton").addEventListener("click", () => {
    if (confirm("¿Comenzar una nueva partida?")) {
        resetGame();
    }
});

document.getElementById("resetScores").addEventListener("click", () => {
    if (confirm("¿Borrar todas las estadísticas?")) {
        scores = {
            whiteWins: 0,
            blackWins: 0,
            draws: 0,
            whitePoints: 0,
            blackPoints: 0
        };

        saveScores();
    }
});

updateScores();
renderBoard();
renderHistory();
updateStatus();
